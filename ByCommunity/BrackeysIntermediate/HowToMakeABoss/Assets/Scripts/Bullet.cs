using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    internal float bulletAcceleration = .2f;
    [SerializeField]
    internal float bulletRange = 20f;
    [SerializeField] 
    internal float damage = 10f;

    float currentSpeed;
    float maxSpeed = 10;
    float startedPosX;
    float currentPosX;

    bool facingRight;

    internal void SetFacingRight(bool _facingRight)
    {
        facingRight = _facingRight;
    }

    private void Start()
    {
        currentSpeed = 0;
        startedPosX =  transform.position.x;
    }

    void Update()
    {
        currentSpeed += bulletAcceleration * (facingRight ? 1 : -1);
        currentPosX = transform.position.x;


        if (facingRight && currentPosX - startedPosX >= bulletRange)
        {
            Destroy(gameObject);
        }
        else if(!facingRight && currentPosX - startedPosX <= -bulletRange)
        {
            Destroy(gameObject);
        }
        else
            transform.position += new Vector3(currentSpeed, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Boss")
        {
            collision.gameObject.GetComponent<BossHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
