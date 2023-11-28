using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource audioFinish;

    private int countPlayer;
    public static bool isKey;
    private GameObject canvasContinue;
    private GameObject canvasSaveScore;  

    public static bool isFinished;

    private void Start()
    {
        countPlayer = 0;
        canvasContinue = transform.Find("CanvasContinue").gameObject as GameObject;
        canvasContinue.SetActive(false);
        canvasSaveScore = transform.Find("CanvasSaveScore").gameObject as GameObject;
        canvasSaveScore.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFinished)
        {
            countPlayer++;
            if(countPlayer >= SystemData.countPlayer && isKey)
            {
                Time.timeScale = 0.0f;
                audioFinish.Play();
                canvasContinue.SetActive(true);
                SaveScore.CountScore();
            }
        }
    }

    public void saveScore()
    {
        SaveScore.CountScore();
        canvasSaveScore.SetActive(true );
    }
}
