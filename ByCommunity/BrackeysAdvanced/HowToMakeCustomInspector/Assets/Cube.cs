using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private void Start() {
        //GenerateColor();
    }

    public void GenerateColor()
    {
        GetComponent<MeshRenderer>().sharedMaterial.color = Random.ColorHSV();
    }

    public void Reset()
    {
        GetComponent<MeshRenderer>().sharedMaterial.color = Color.white;
    }
}
