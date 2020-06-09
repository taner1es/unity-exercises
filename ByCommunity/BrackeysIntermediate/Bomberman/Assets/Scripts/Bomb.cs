using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countDown = 2f;

    private void Update()
    {
        countDown -= Time.deltaTime;

        if(countDown <= 0)
        {
            FindObjectOfType<MapDestroyer>().Explode(transform.position);
            Destroy(gameObject);
        }
    }
}
