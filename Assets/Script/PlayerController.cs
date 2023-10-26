using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string inputHorizontal;
    public string inputVertical;
    private float dirX = 0f;
    private float speedCharacter = 7f;
    private float jumpCharacter = 14f;
    private Rigidbody2D rb;
    private Animator aniPlayer;
    private SpriteRenderer spritePlayer;
    enum anim { idle, run, jump, fall, doublejump }
    private anim state;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aniPlayer = GetComponent<Animator>();
        spritePlayer = GetComponent<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


    private void Update()
    {
        dirX = Input.GetAxisRaw(inputHorizontal);
        rb.velocity = new Vector2(dirX * speedCharacter, rb.velocity.y);
        if (Input.GetButtonDown(inputVertical))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpCharacter);
        }

        UpdateAnimator();
    }

    private void UpdateAnimator()
    {

        if (dirX > 0)
        {
            spritePlayer.flipX = false;
            state = anim.run;
        }
        else if (dirX < 0)
        {
            spritePlayer.flipX = true;
            state = anim.run;
        }
        else
        {
            state = anim.idle;
        }

        if (rb.velocity.y > 0f)
        {
            state = anim.jump;
        }

        if (rb.velocity.y < 0f)
        {
            state = anim.fall;
        }

        aniPlayer.SetInteger("state", (int)state);
    }
}
