using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public static bool isDead;
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject canvasDead;
    [SerializeField] private AudioSource audioDead;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canvasDead = transform.Find("CanvasDead").gameObject as GameObject;
        canvasDead.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            audioDead.Play();
            isDead = true;
            Die();
            rb.bodyType = RigidbodyType2D.Static;
            canvasDead.SetActive(true);
        }
    }

    private void Die()
    {
        anim.SetBool("deadth", true);
    }
}
