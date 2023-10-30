using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string inputHorizontal;
    public string inputVertical;

    [SerializeField] private LayerMask mapMask;
    [SerializeField] private AudioSource audioJump;

    private bool isDoublejump = false;
    private float dirX;
    private float speedCharacter = 7.0f;
    private float jumpCharacter = 14.0f;
    private Rigidbody2D rb;
    private Animator animatorPlayer;
    private SpriteRenderer spritePlayer;
    private BoxCollider2D colliderPlayer;
    enum anim { idle, run, jump, fall, doublejump}
    anim state;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        animatorPlayer = GetComponent<Animator>();
        spritePlayer = GetComponent<SpriteRenderer>();
        colliderPlayer = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw(inputHorizontal);
        rb.velocity = new Vector2(dirX * speedCharacter, rb.velocity.y);
        if(Input.GetButtonDown(inputVertical))
        {
            if(isDoublejump || iSGround())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpCharacter);
                isDoublejump = !isDoublejump;
            }
        }

        updateAnimation();
    }

    private void updateAnimation()
    {
        if(dirX > 0f)
        {
            spritePlayer.flipX = false;
            state = anim.run;
        }else if(dirX < 0f)
        {
            spritePlayer.flipX = true;
            state = anim.run;
        }
        else
        {
            state = anim.idle;
        }

        if(rb.velocity.y > 0.5f)
        {
            audioJump.Play();
            state = anim.jump;
            if(!isDoublejump)
            {
                state = anim.doublejump;
            }
        }

        if(rb.velocity.y < -0.5f)
        {
            state = anim.fall;
        }

        animatorPlayer.SetInteger("state", (int) state);
    }

    private bool iSGround()
    {
        return Physics2D.BoxCast(colliderPlayer.bounds.center, colliderPlayer.bounds.size, 0f, Vector2.down, .1f, mapMask);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            isDoublejump = false;
        }
    }
}
