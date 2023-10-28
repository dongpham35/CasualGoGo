using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowCanvas : MonoBehaviour
{
    public Text txtScore;


    private void Update()
    {
        txtScore.text = "Cherries: " + ItemCollection.score.ToString();
    }

}
