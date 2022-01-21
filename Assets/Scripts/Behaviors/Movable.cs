using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public Vector2 direction = Vector2.zero;
    
    public float speed = 1;

    private void FixedUpdate() {
        Vector3 newPos = transform.position + new Vector3(direction.x, direction.y, 0) * speed * Time.fixedDeltaTime;
        transform.position = newPos;
    }
}
