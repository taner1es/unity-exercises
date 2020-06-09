using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rbPlayer1;
    public Rigidbody rbPlayer2;

    public float speedPlayer1 = 5f;
    public float speedPlayer2 = 5f;

    public GroundCheck groundCheckPlayer1;
    public GroundCheck groundCheckPlayer2;

    Vector3 directionPlayer1;
    Vector3 directionPlayer2;

    private void Update()
    {

        // Player1 Input Handling
        directionPlayer1 = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
            directionPlayer1 = Vector3.right;
        if (Input.GetKey(KeyCode.A))
            directionPlayer1 += Vector3.left;
        if (Input.GetKey(KeyCode.W))
            directionPlayer1 += Vector3.up;
        if (Input.GetKey(KeyCode.S) && !groundCheckPlayer1.grounded)
            directionPlayer1 += Vector3.down;

        // Player1 Add GForce if no up key input handled
        if (directionPlayer1.y <= 0 && !groundCheckPlayer1.grounded)
            directionPlayer1 += Vector3.down;

        // Player2 Input Handling
        directionPlayer2 = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
            directionPlayer2 = Vector3.right;
        if (Input.GetKey(KeyCode.LeftArrow))
            directionPlayer2 += Vector3.left;
        if (Input.GetKey(KeyCode.UpArrow))
            directionPlayer2 += Vector3.up;
        if (Input.GetKey(KeyCode.DownArrow) && !groundCheckPlayer2.grounded)
            directionPlayer2 += Vector3.down;

        // Player2 Add GForce if no up key input handled
        if (directionPlayer2.y <= 0 && !groundCheckPlayer2.grounded)
            directionPlayer2 += Vector3.down;

        // Apply Player1 Movement
        if(directionPlayer1 != Vector3.zero)
            rbPlayer1.AddForce(directionPlayer1.normalized * Time.deltaTime * 100 * speedPlayer1, ForceMode.Force);

        // Apply Player2 Movement
        if (directionPlayer2 != Vector3.zero)
            rbPlayer2.AddForce(directionPlayer2.normalized * Time.deltaTime * 100 * speedPlayer2, ForceMode.Force);

    }
}
