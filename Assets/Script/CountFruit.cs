using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountFruit : MonoBehaviour
{
    public static int count;

    private void Start()
    {
        count = gameObject.transform.childCount;
    }
}
