using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flips : MonoBehaviour
{
    SpriteRenderer selfRenderer;
    Rigidbody2D selfRigidBody;
    Movable selfMovable;
    bool initial;
    private void Start() {
        selfMovable = GetComponent<Movable>();
        selfRenderer = GetComponent<SpriteRenderer>();
        selfRigidBody = GetComponent<Rigidbody2D>();
        initial = selfRenderer.flipX;    
    }


    private void Update() {
        if (selfMovable.direction.magnitude > 0) {
            if (selfRigidBody.velocity.x < 0) {
                selfRenderer.flipX = !initial;
            } else {
                selfRenderer.flipX = initial;
            }
        }
    }
}
