using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Give this to object that move by themselves.
/// </summary>
public class Movable : MonoBehaviour
{
    public Vector2 direction = Vector2.zero;
    
    public float speed = 1;

    Rigidbody2D selfRigidBody;
    Animator selfAnimator;

    private void Start() {
        selfRigidBody = GetComponent<Rigidbody2D>();
        selfAnimator = GetComponent<Animator>();
        if (tag == "Player") {
            speed *= Player.GetModifier("playerSpeed");
        }
    }

    private void FixedUpdate() {
        Vector3 newVelocity = new Vector3(direction.x, direction.y, 0) * speed;
        selfRigidBody.velocity = newVelocity;
        if (tag == "Player") {
            selfAnimator.SetBool("isIdle", !(newVelocity.magnitude > 0));
        }
    }
}
