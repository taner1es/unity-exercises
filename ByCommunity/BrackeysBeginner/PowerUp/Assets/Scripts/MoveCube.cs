using UnityEngine;

public class MoveCube : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float speed = 1000f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(Vector3.up * speed * Time.deltaTime);
        
    }
}
