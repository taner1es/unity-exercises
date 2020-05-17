using System;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject grenadePrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowGrenade();
        }
    }

    private void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position + transform.forward , transform.rotation);

        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        //rb.AddForce(transform.InverseTransformDirection(transform.forward) * throwForce);

        rb.transform.position = transform.position + Camera.main.transform.forward;
        rb.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Acceleration);
    }
}
