using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private int countPlayer;
    public static bool isKey;
    private GameObject canvasContinue;

    public static bool isFinished;

    private void Start()
    {
        countPlayer = 0;
        canvasContinue = transform.Find("CanvasContinue").gameObject as GameObject;
        canvasContinue.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFinished)
        {
            countPlayer++;
            if(countPlayer >= SystemData.countPlayer && isKey)
            {
                canvasContinue.SetActive(true);
            }
        }
    }
}
