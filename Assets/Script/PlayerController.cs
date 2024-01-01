using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public string inputHorizontal;
    public string inputVertical;
    public KeyCode inputInteract;
    public Text namePlayer;

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
    private Vector2 lookDirection = new Vector2(1, 0);
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
                audioJump.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpCharacter);
                isDoublejump = !isDoublejump;
            }
        }

        if (Input.GetKeyDown(inputInteract))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }

        updateAnimation();
    }

    private void updateAnimation()
    {
        if(dirX > 0f)
        {
            lookDirection.Set(1, 0);
            spritePlayer.flipX = false;
            state = anim.run;
        }else if(dirX < 0f)
        {
            lookDirection.Set(-1, 0);
            spritePlayer.flipX = true;
            state = anim.run;
        }
        else
        {
            state = anim.idle;
        }

        if(rb.velocity.y > 0.5f)
        {
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
