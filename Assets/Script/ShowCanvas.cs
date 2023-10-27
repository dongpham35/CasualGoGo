using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowCanvas : MonoBehaviour
{
    [SerializeField] private Text txtScore;
    [SerializeField] private Canvas canvasDead;
    [SerializeField] private Canvas canvasContinue;
    [SerializeField] private Canvas canvasPause;

    private void Start()
    {
        canvasDead.gameObject.SetActive(false);
        canvasContinue.gameObject.SetActive(false);
        canvasPause.gameObject.SetActive(false);
    }
    

    private void Update()
    {
        if (Dead.isDead)
        {
            canvasDead.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvasPause.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void showCanvasContinue()
    {
       canvasContinue.gameObject.SetActive(true);
    }
    public void showscore()
    {
        txtScore.text = "Cherries: " + ItemCollection.score;
    }

}
