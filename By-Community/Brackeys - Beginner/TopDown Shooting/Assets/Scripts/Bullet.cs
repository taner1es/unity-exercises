using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }
}
