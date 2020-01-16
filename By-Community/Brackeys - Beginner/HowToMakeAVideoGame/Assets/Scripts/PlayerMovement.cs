using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    void FixedUpdate()
    {
        rb.AddForce(0, 0, Random.Range(100, 1000) * Time.deltaTime);
    }
}
