using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContronller : MonoBehaviour
{

    private Camera cam;
    private float distanceMultiplayer;
    public float smoothSpeed = 0.125f;
    private int minSizecamera = 5;
    private int maxSizecamera = 20;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    //SpawnPlayer.player1 == null || SpawnPlayer.player2 == null
    private void FixedUpdate()
    {
        if (SystemData.countPlayer == 1)
        {
            try
            {
                if(SpawnPlayer.player1 != null)
                {
                    transform.position = SpawnPlayer.player1.transform.position + new Vector3(0f, 0f, -10f);
                }
            }catch(System.Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        else if (SystemData.countPlayer == 2)
        {
            try
            {
                if(SpawnPlayer.player1 != null && SpawnPlayer.player2 != null)
                {
                    distanceMultiplayer = Vector3.Distance(SpawnPlayer.player1.transform.position, SpawnPlayer.player2.transform.position);
                    if (distanceMultiplayer / 2 > cam.orthographicSize && cam.orthographicSize < maxSizecamera)
                    {
                        cam.orthographicSize += 0.1f;
                    }
                    if (distanceMultiplayer / 2 < cam.orthographicSize && cam.orthographicSize > minSizecamera)
                    {
                        cam.orthographicSize -= 0.1f;
                    }
                    Vector3 middlePoint = (SpawnPlayer.player1.transform.position + SpawnPlayer.player2.transform.position) / 2f;
                    Vector3 desiredPosition = middlePoint;
                    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                    Vector3 temp = new Vector3(0, 0, -10);
                    transform.position = smoothedPosition + temp;
                }
            }catch(System.Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        
    }
}
