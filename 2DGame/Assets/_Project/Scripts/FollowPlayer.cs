using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 bounds;

    private void LateUpdate()
    {
        Vector3 movePos = Vector3.zero;

        float moveX = target.position.x - transform.position.x;
        //If target is outside the cameras x bounding box.
        if (moveX > bounds.x || moveX < -bounds.x)
        {
            if (transform.position.x < target.position.x)
            {
                movePos.x = moveX - bounds.x;
            }
            else
            {
                movePos.x = moveX + bounds.x;
            }
        }

        float moveY = target.position.y - transform.position.y;
        //If target is outside the cameras x bounding box.
        if (moveY > bounds.y || moveY < -bounds.y)
        {
            if (transform.position.y < target.position.y)
            {
                movePos.y = moveY - bounds.y;
            }
            else
            {
                movePos.y = moveY + bounds.y;
            }
        }

        transform.Translate(movePos);
    }
}
