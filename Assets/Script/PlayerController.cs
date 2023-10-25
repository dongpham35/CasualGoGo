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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


    void Update()
    {
        dirX = Input.GetAxisRaw(inputHorizontal);
        rb.velocity = new Vector2(dirX * speedCharacter, rb.velocity.y);

        if (Input.GetButtonDown(inputVertical))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpCharacter);
        }
    }
}
