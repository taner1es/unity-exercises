using UnityEditor.UIElements;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool grounded;

    private void Start()
    {
        grounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Platform")
        {
            grounded = true;
            Debug.Log("Grounded");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Platform")
        {
            grounded = false;
            Debug.Log("unGrounded");
        }
    }
}
