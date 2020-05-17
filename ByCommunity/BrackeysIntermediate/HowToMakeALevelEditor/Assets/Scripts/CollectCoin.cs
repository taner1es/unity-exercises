using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public string coinTag = "Coin";
    public GameObject collectFx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            Instantiate(collectFx, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
