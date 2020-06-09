using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 100;
    [Range(0.0f, 1.0f)]
    public float powerUpScaleSpeed = 0.5f;


    private bool powerUpActive = false;
    private float powerUpMultiplier = 0;


    private void Update()
    {
        if (powerUpActive)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * powerUpMultiplier, powerUpScaleSpeed);
            GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
        }
        else if(!powerUpActive && transform.localScale.magnitude > Vector3.one.magnitude)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, powerUpScaleSpeed);
            GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f);
        }
    }

    public void PowerUpEnable(float multiplier)
    {
        powerUpActive = true;
        powerUpMultiplier = multiplier;
    }

    public void PowerUpDisable()
    {
        powerUpActive = false;
    }
}
