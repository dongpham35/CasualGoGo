using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHightScore : MonoBehaviour
{
    [SerializeField] Text[] texts;
    [SerializeField] Canvas canvas;

    private void Start()
    {
        canvas.enabled = false;
    }

    public void ShowScore()
    {
        canvas.enabled=true;
        SaveScore.LoadFileScore("Score.txt");
        int i = 0;
        foreach ( var score in SaveScore.Dscore)
        {
            if (i == 5) break;
            else
            {
                if (!string.IsNullOrEmpty(score.Key.ToString())) texts[i].text = score.Key.ToString();
                else texts[i].text = "Undefine";
                i++;
            }
        }
    }

    public void LoadFile()
    {
        SaveScore.LoadFileScore("Score.txt");
    }

    public void QuitScore()
    {
        canvas.enabled=false;
    }

    public void SaveToFile()
    {
        SaveScore.WriteFile("Score.txt");
    }
}
