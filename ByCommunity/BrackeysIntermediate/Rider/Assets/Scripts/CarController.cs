using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 20f;
    public float rotationSpeed = 2f;

    bool move = false;
    bool isGrounded = false;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move = Input.GetMouseButton(0);
    }

    private void FixedUpdate()
    {
        if(move)
        {
            if (isGrounded)
                rb.AddForce(Vector2.right * speed * Time.fixedDeltaTime * 100, ForceMode2D.Force);
            else
                rb.AddTorque(rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D()
    {
        isGrounded = false;
    }
}
