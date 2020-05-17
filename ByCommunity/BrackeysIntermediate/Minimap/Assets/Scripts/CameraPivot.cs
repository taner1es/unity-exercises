using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public Transform TracedObject;

    [Range(0.001f, 1f)]
    public float posSpeed = .5f;
    [Range(0.001f, 1f)]
    public float rotSpeed = .5f;
    private void Start()
    {
        transform.position = TracedObject.position;
        transform.rotation = TracedObject.rotation;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, TracedObject.position, Time.deltaTime * posSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, TracedObject.rotation, Time.deltaTime * rotSpeed);
    }
}
