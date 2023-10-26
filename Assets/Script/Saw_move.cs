using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw_move : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, - 180 * moveSpeed * Time.deltaTime);
    }
}
