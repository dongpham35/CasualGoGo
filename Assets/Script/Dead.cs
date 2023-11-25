using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public static bool isDead;
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject canvasDead;
    private GameObject canvasSaveScore;
    [SerializeField] private AudioSource audioDead;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canvasDead = transform.Find("CanvasDead").gameObject as GameObject;
        canvasSaveScore = transform.Find("CanvasSaveScore").gameObject as GameObject;
        canvasSaveScore.SetActive(false);
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
        Time.timeScale = 0.0f;
        anim.SetBool("deadth", true);
    }


    public void showCanvasSaveScore()
    {
        canvasSaveScore.SetActive(true );
        canvasDead.SetActive(false);
    }
}
