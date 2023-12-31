using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemData : MonoBehaviour
{
    public static int countPlayer = 0;

    public void setOnePlayer()
    {
        countPlayer = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void setTwoPlayer()
    {
        countPlayer = 2;
        SceneManager.LoadScene(2);
    }

    public void onclickStart()
    {
        PlayerPrefs.SetInt("CurrentHealth", 3);
        SceneManager.LoadScene(3);
        
    }


    public void onclickContinure()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void onclickExit()
    {
        Application.Quit();
    }

    public void onclickMenuGame()
    {
        SceneManager.LoadScene(0);
    }

}
