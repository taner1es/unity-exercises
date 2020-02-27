using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offset;
    [SerializeField] private float zoomSpeed = 4f;
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float maxZoom = 15f;

    [SerializeField] private float pitch = 2f;

    [SerializeField] private float currentZoom = 10f;
    
    [SerializeField] private float yawSpeed = 100f;
    [SerializeField] private float currentYaw = 0f;
    
    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
