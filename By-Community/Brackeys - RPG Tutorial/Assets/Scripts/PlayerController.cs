using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask movementMask;
    
    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        // Left mouse click event
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
            }

        }

        // Right mouse click event
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                   
            }

        }
    }
}
