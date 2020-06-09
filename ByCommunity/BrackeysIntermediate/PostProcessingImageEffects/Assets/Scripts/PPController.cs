using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PPController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<PostProcessVolume>().enabled = !gameObject.GetComponent<PostProcessVolume>().enabled;
        }
    }
}
