using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGun : MonoBehaviour
{
    public GameObject explosion;
    public Camera cam;
    public TimeManager timeManager;
        
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit _hitInfo;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hitInfo))
        {
            Instantiate(explosion, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));

            timeManager.DoSlowmotion();
        }
    }
}
