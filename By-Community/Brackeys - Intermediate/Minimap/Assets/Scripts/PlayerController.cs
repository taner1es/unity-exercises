using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float rotSpeed = 2f;

    CharacterController cc;
    float gravity = 9.81f;
    Vector3 direction;
    float rotation;
    float fallingTimer = 0f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // movement
        // --------
        direction = Vector3.zero;

            // falling
            // --------
            if (!cc.isGrounded)
            {
                fallingTimer += Time.fixedTime;
                fallingTimer /= 60f;

                Debug.Log("falling timer: " + fallingTimer);
                direction += -transform.up * gravity * fallingTimer/60;
            }
            else
                fallingTimer = 0f;
            // --------

        if (Input.GetKey(KeyCode.UpArrow))
            direction += transform.forward;
        if (Input.GetKey(KeyCode.DownArrow))
            direction -= transform.forward;

        direction.Normalize();
        //direction *= Time.deltaTime;
        direction *= speed;
        Debug.Log("direction: " + direction);
        cc.SimpleMove(direction);
        // --------

        // rotation
        // --------
        if (Input.GetKey(KeyCode.RightArrow))
            rotation += 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            rotation += -1;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(transform.rotation.x, rotation * rotSpeed, transform.rotation.z)), .15f);
        // --------
    }
}
