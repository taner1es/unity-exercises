using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject particleExplosion;
    [Range(0.001f, 1f)]
    public float smoothness = .125f;
    [Range(1f, 10f)]
    public float durationRate = 1f;
    float elapsed = 0.0f;

    public IEnumerator Shake(float duration, float size)
    {
        while(elapsed < duration / durationRate)
        {
            float randomX = Random.Range(-1f, 1f) * size;
            float randomY = Random.Range(-1f, 1f) * size;
            
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(randomX, randomY, 0), smoothness);
            
            elapsed += Time.deltaTime;

            yield return null;
        }
        
        transform.localPosition = Vector3.zero;
        elapsed = 0.0f;
    }
}
