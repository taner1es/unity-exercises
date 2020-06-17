using System;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public static List<Attractor> Attractors;

    public Rigidbody rb;

    const float G = 667.4f;
    float scaleForce = 100000f;

    private void Start()
    {
        rb.mass = transform.localScale.magnitude;
    }

    private void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<Attractor>();

        Attractors.Add(this);
    }

    private void OnDisable()
    {
        Attractors.Remove(this);
    }

    private void FixedUpdate()
    {
        foreach(Attractor attractor in Attractors)
        {
            if(attractor != this)
                Attract(attractor);
        }
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = scaleForce * G * (float)(rb.mass * rbToAttract.mass / Math.Pow(distance, 2));
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
