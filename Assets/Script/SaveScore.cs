using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveScore : MonoBehaviour
{
    [SerializeField] private InputField txtName;
    private string path = "~/GameBTL/Score";
    private void Start()
    {
        string name = txtName.text;
        

    }

    public void Save()
    {
        if (!string.IsNullOrEmpty(name))
        {

        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
