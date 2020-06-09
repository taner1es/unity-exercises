using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public GameObject Camera;
    public float magnitude = .4f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<ParticleSystem>().Play();
            StartCoroutine(Camera.GetComponent<CameraShake>().Shake(GetComponent<ParticleSystem>().main.duration, magnitude));
        }       
    }
}
