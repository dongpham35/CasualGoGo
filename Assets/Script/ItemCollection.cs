using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    public static int score = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            score++;
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            Finish.isKey = true;
        }
    }
}
