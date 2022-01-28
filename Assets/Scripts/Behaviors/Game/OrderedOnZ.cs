using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to enforce proper draw order by snapping objects to grid on Z.
/// </summary>
public class OrderedOnZ : MonoBehaviour
{
    Vector3 offset;
    SpriteRenderer selfRenderer;
    void Start()
    {
        selfRenderer = GetComponent<SpriteRenderer>();

        Vector2 offset2D = GetComponent<Collider2D>().offset;

        offset = new Vector3(offset2D.x, offset2D.y, 0);
    }

    void Update()
    {
        selfRenderer.sortingOrder = -(int)((transform.position + offset) * 100).y;
    }
}
