using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicCharacter : MonoBehaviour
{
    public Sprite[] sprites;
    private Image img;
    private int index = 0;
    private int count;

    private void Start()
    {
        img = GetComponent<Image>();
        count = sprites.Length;
        StartCoroutine(Wait());
        
    }
    IEnumerator Wait()
    {
        while (true)
        {
            if (index == count - 1) index = 0;
            img.sprite = sprites[index];
            index++;
            yield return new WaitForSeconds(0.05f);
        }
    }
    
}
