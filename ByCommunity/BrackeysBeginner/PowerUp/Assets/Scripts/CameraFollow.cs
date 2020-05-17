using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectToFollow;
    [SerializeField]
    Vector3 offset = new Vector3(0,0,0);
    [SerializeField]
    float smoothSpeed = .125f;

    private void FixedUpdate()
    {
        Vector3 desiredPos = objectToFollow.position + offset;
        transform.position =  Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.LookAt(objectToFollow);
    }
}
