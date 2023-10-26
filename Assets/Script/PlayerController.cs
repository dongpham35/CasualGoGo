using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string inputHorizontal;
    public string inputVertical;

    private float dirX;
    private float speedCharacter = 7.0f;
    private float jumpCharacter = 14.0f;
    private Rigidbody2D rb;
    private Animator animatorPlayer;
    private SpriteRenderer spritePlayer;
    enum anim { idle, run, jump, fall, doublejump}
    anim state;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        animatorPlayer = GetComponent<Animator>();
        spritePlayer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw(inputHorizontal);
        rb.velocity = new Vector2(dirX * speedCharacter, rb.velocity.y);
        if(Input.GetButtonDown(inputVertical))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpCharacter);
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

        if(rb.velocity.y > 0f)
        {
            state = anim.jump;
        }

        if(rb.velocity.y < 0f)
        {
            state = anim.fall;
        }

        animatorPlayer.SetInteger("state", (int) state);
    }

}
