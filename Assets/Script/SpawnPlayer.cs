using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] prefabsCharacter;
    private int index1, index2;
    private void Start()
    {
        Load();
        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            if (SystemData.countPlayer == 1)
            {
                GameObject player1 = Instantiate(prefabsCharacter[index1], new Vector2(-9, 1.5f),Quaternion.identity);
                PlayerController script = player1.GetComponent<PlayerController>();
                script.inputHorizontal = "Horizontal";
                script.inputVertical = "Vertical";
            }
            else if (SystemData.countPlayer == 2)
            {
                GameObject player1 = Instantiate(prefabsCharacter[index1], new Vector2(-9, 1.5f), Quaternion.identity);
                GameObject player2 = Instantiate(prefabsCharacter[index2], new Vector2(-9, 1.5f), Quaternion.identity);
                PlayerController script = player1.GetComponent<PlayerController>();
                script.inputHorizontal = "Horizontal";
                script.inputVertical = "Vertical";
                PlayerController script1 = player2.GetComponent<PlayerController>();
                script1.inputHorizontal = "Horizontal1";
                script1.inputVertical = "Vertical1";
            }
        }
    }
    private void Load()
    {
        index1 = PlayerPrefs.GetInt("selected1");
        index2 = PlayerPrefs.GetInt("selected2");
    }
}
