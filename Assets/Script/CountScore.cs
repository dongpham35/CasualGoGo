using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScore : MonoBehaviour
{
    private Text txtTime;
    public static float runtime;
    private float startTime;
    private bool timeRunning;
    private float minutes = 0.0f;
    private float seconds = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        runtime = 0.0f;
        startTime = 0;
        GameObject canvas = transform.Find("Timer").gameObject as GameObject;
        txtTime = canvas.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRunning)
        {
            runtime = Time.time - startTime;
            UpdateTime(runtime);
        }
    }

    private void UpdateTime(float time)
    {
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        txtTime.text = string.Format(format:"{0:00}:{1:00}", minutes, seconds);
    }
    public void ResetTimer()
    {
        startTime = 0;
        UpdateTime(0.0f);
    }

    public void StartTimer()
    {
        startTime = Time.time;
        timeRunning = true;
    }

    public void StopTimer()
    {
        timeRunning = false;
    }
}
