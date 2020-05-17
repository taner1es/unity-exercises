using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("Shoot");
        }
    }

    private IEnumerator Shoot()
    {
        if (animator.GetFloat("Speed") == 0f)
        {
            if (!animator.GetBool("Attack"))
                animator.SetBool("Attack", true);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(firePoint.parent.rotation.eulerAngles + new Vector3(0f, 0f, -90)));
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            yield return new WaitForSeconds(.2f);
            animator.SetBool("Attack", false);
        }

    }
}
