using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject []health;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        
        if (PlayerPrefs.HasKey("CurrentHealth"))
        {
            health[0].SetActive(false);
            health[1].SetActive(false);
            health[2].SetActive(false);
            currentHealth = PlayerPrefs.GetInt("CurrentHealth");
            for (int i = 0; i < currentHealth; i++)
            {
                health[i].SetActive(true);
            }
        }
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("isDead") == 1)
        {
            health[currentHealth - 1].SetActive(false);
            PlayerPrefs.SetInt("CurrentHealth", currentHealth - 1);
            Debug.Log(PlayerPrefs.GetInt("CurrentHealth"));
            PlayerPrefs.SetInt("isDead", 0);
        }
    }

}