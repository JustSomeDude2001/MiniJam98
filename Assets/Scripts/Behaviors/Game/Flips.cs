using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flips : MonoBehaviour
{
    SpriteRenderer selfRenderer;
    Rigidbody2D selfRigidBody;
    bool initial;
    private void Start() {
        selfRenderer = GetComponent<SpriteRenderer>();
        selfRigidBody = GetComponent<Rigidbody2D>();
        initial = selfRenderer.flipX;    
    }


    private void Update() {
        if (selfRigidBody.velocity.x < 0) {
            selfRenderer.flipX = !initial;
        } else {
            selfRenderer.flipX = initial;
        }
    }
}
