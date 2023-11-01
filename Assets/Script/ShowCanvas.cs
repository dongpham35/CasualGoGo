using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowCanvas : MonoBehaviour
{
    public Text txtScore;
    
    private bool canvaResume;
    private GameObject canvaPause;
    [SerializeField] private AudioSource audioPlay;

    private void Start()
    {
        canvaPause = transform.Find("CanvasPause").gameObject as GameObject;
        canvaPause.SetActive(false);
    }

    private void Update()
    {
        txtScore.text = "Cherries: " + ItemCollection.score.ToString();
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(canvaResume)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        canvaPause.SetActive(false);
        audioPlay.mute = false;
        Time.timeScale = 1.0f;
        canvaResume = false;
    }

    private void PauseGame()
    {
        canvaPause.SetActive(true);
        audioPlay.mute = true;
        Time.timeScale = 0.0f;
        canvaResume = true;
    }

}
