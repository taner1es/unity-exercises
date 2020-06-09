using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateCamera : MonoBehaviour
{
    public Slider sensitivitySlider;
    public float sensitivity = 0.1f;

    private void Update()
    {
        float mouseRawX = Input.GetAxisRaw("Mouse X");
        float mouseRawY = -Input.GetAxisRaw("Mouse Y");
        
        Quaternion origin = gameObject.transform.rotation;
        
        if (mouseRawX != 0 || mouseRawY != 0)
        {
            float resultX = Mathf.Clamp(origin.eulerAngles.x + mouseRawY * sensitivity, 35f, 40f);
            float resultY = Mathf.Clamp(origin.eulerAngles.y + mouseRawX * sensitivity, 310f, 357f);

            origin.eulerAngles = new Vector3(resultX, resultY, origin.eulerAngles.z);

            gameObject.transform.rotation = origin;
        }
    }

    public void SensitivitySliderUpdate()
    {
        sensitivity = sensitivitySlider.value;
        Debug.Log("sensitivity changed: " + sensitivitySlider.value);
    }
}
