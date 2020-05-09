using System;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 700f;

    public GameObject explosionEffect;

    bool hasExploded = false;

    private void Start()
    {
        Explode();
    }

    private void Explode()
    {
        Debug.Log("BOOM!");

        var psMain = Instantiate(explosionEffect, transform.position, transform.rotation).GetComponent<ParticleSystem>().main;
        psMain.stopAction = ParticleSystemStopAction.Destroy;
        

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider nearbyObject in collidersToDestroy)
        {
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if(dest != null)
            {
                dest.Destroy();
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
