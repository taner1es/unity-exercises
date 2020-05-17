using System.Collections;
using UnityEngine;

public class Weapon_Raycasting : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        gameObject.GetComponent<Animator>().SetBool("Attack", true);

        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(Instantiate(impactEffect, hitInfo.point, Quaternion.identity), .2f);

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);

        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(.1f);

        lineRenderer.enabled = false;

        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<Animator>().SetBool("Attack", false);
    }
}
