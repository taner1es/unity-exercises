using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject camera;

    // Update is called once per frame
    void Update()
    {
        camera.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
    }
}
