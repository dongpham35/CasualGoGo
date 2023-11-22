using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScore : MonoBehaviour
{
    [SerializeField] private Text txtTime;
    public static float runtime;
    private float startTime;
    private bool timeRunning;
    // Start is called before the first frame update
    void Start()
    {
        runtime = 0.0f;
        startTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRunning)
        {
            runtime = Time.time - startTime;
            UpdateTime(runtime);
        }
    }

    private void UpdateTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        txtTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Reset()
    {
        startTime = 0;
        UpdateTime(0f);
    }
}
