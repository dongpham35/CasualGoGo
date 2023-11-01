using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static int preScore = 0;
    public void NextScene()
    {
        preScore = ItemCollection.score;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MoveMenuGame()
    {
        Time.timeScale = 1.0f;
        ItemCollection.score = 0;
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        ItemCollection.score = preScore;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

}
