using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void NextScene()
    {
        Time.timeScale = 1.0f;
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
        PlayerPrefs.SetInt("CurrentHealth", 3);
        Time.timeScale = 1.0f;
        ItemCollection.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

}
