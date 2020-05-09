using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    bool isRewinding = false;

    float recordTime = 5f;

    List<PointInTime> pointsInTime;

    Rigidbody rb;

    private void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    private void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        Debug.Log(pointsInTime.Count);
    }

    private void Record()
    {
        if(pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        Debug.Log(pointsInTime.Count);
    }

    private void StartRewind()
    {
        isRewinding = true;
        if(rb != null) rb.isKinematic = true;
    }

    private void StopRewind()
    {
        isRewinding = false;
        if(rb != null) rb.isKinematic = false;
    }

}
