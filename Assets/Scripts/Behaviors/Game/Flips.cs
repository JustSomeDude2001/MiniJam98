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
        if (Player.isOnPause) {
            return;
        }
        
        if (Mathf.Abs(selfMovable.direction.x) > 0.01) {
            if (selfMovable.direction.x < 0) {
                selfRenderer.flipX = !initial;
            } else {
                selfRenderer.flipX = initial;
            }
        }
    }
}
