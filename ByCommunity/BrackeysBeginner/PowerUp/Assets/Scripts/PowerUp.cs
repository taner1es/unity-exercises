using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;
    public float duration = 4f;

    public GameObject pickUpEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider player)
    {
        float particleEffectDuration = pickUpEffect.GetComponent<ParticleSystem>().main.duration;
        Destroy(Instantiate(pickUpEffect, transform.position + new Vector3(0f, 2f, 0f), transform.rotation), particleEffectDuration);

        Color col = player.GetComponent<MeshRenderer>().material.color;
        player.GetComponent<PlayerStats>().PowerUpEnable(multiplier);
        player.GetComponent<MeshRenderer>().material.color = new Color(col.r * multiplier,col.g,col.b);
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.health *= multiplier;
        


        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;


        yield return new WaitForSeconds(duration);

        stats.health /= multiplier;
        player.GetComponent<MeshRenderer>().material.color = new Color(col.r / multiplier, col.g, col.b);
        player.GetComponent<PlayerStats>().PowerUpDisable();

        Destroy(gameObject);
    }
}
