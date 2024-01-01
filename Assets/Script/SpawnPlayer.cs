using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] prefabsCharacter;
    public static GameObject player1;
    public static GameObject player2;
    private int index1, index2;
    private void Start()
    {
        Load();
        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            if (SystemData.countPlayer == 1)
            {
                player1 = Instantiate(prefabsCharacter[index1], new Vector3(-9f, 1.5f, 0f),Quaternion.identity);
                PlayerController script = player1.GetComponent<PlayerController>();
                script.inputHorizontal = "Horizontal";
                script.inputVertical = "Vertical";
                script.namePlayer.text = "Player 1";
                script.inputInteract = KeyCode.X;

            }
            else if (SystemData.countPlayer == 2)
            {
                player1 = Instantiate(prefabsCharacter[index1], new Vector3(-9, 1.5f, 0f), Quaternion.identity);
                player2 = Instantiate(prefabsCharacter[index2], new Vector3(-9, 1.5f, 0f), Quaternion.identity);
                PlayerController script = player1.GetComponent<PlayerController>();
                script.inputHorizontal = "Horizontal";
                script.inputVertical = "Vertical";
                script.namePlayer.text = "Player 1";
                script.namePlayer.color = Color.blue;
                script.inputInteract = KeyCode.X;
                PlayerController script1 = player2.GetComponent<PlayerController>();
                script1.inputHorizontal = "Horizontal1";
                script1.inputVertical = "Vertical1";
                script1.namePlayer.text = "Player 2";
                script1.namePlayer.color = Color.black;
                script1.inputInteract = KeyCode.J;
            }
        }
    }
    private void Load()
    {
        index1 = PlayerPrefs.GetInt("selected1");
        index2 = PlayerPrefs.GetInt("selected2");
    }
}
