using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject path;
    Transform[] transformPath;
    Rigidbody2D rb;
    Vector2 direction;
    float moveSpeed = 5f;

    bool stop = false;

    int currentTargetIndex = 0;

    void OnEnable()
    {
        transformPath = path.GetComponentsInChildren<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (!stop)
        {
            float distance = Vector2.Distance(transformPath[currentTargetIndex].position, transform.position);
            if (distance > 0.05f)
            {
                //moving
                direction = (transformPath[currentTargetIndex].position - transform.position).normalized;
                rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

                //rotating
                Vector3 diff = transformPath[currentTargetIndex].position - transform.position;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            }
            else
            {
                currentTargetIndex++;
                if (currentTargetIndex == transformPath.Length)
                {
                    stop = true;
                    rb.velocity = Vector2.zero;
                }
                    
            }
        }
    }
}
