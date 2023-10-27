using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public static int countPlayer;
    public static bool isKey;

    private bool isFinished = false;

    private void Start()
    {
        countPlayer = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFinished)
        {
            if(countPlayer >= 2 && isKey)
            {
                new ShowCanvas().showCanvasContinue();
                isFinished = true;
                countPlayer = 0;
            }
            else
            {
                countPlayer++;
            }
        }
    }
}
