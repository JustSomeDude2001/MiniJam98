using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jumping is done by simply switching collider to trigger mode.
/// </summary>
public class Jumps : MonoBehaviour
{
    public float duration;
    public float cooldown;
    float lastJumpTime = 0;
    Animator selfAnimator;
    Collider2D selfCollider;
    Movable selfMovable;
    SpriteRenderer selfRenderer;
    OrderedOnZ selfOrderer;

    bool isJumping = false;

    void Start()
    {
        selfAnimator = GetComponent<Animator>();
        selfCollider = GetComponent<Collider2D>();
        selfMovable = GetComponent<Movable>();
        selfRenderer = GetComponent<SpriteRenderer>();
        selfOrderer = GetComponent<OrderedOnZ>();
    }

    public bool CanJump() {
        if (Time.time - lastJumpTime < cooldown) {
            return false;
        }

        if (isJumping == true) {
            return false;
        }
        
        Vector3 offset = new Vector3(selfMovable.direction.x, selfMovable.direction.y, 0) * selfMovable.speed * duration;

        Vector3 newPos = offset + transform.position;
        Vector3Int gridPos = GridMatrix.selfGrid.WorldToCell(newPos);

        if (GridMatrix.GetObject(gridPos) == null) {
            return true;
        } else {
            return false;
        }
    }

    public void Jump() {
        if (!CanJump()) {
            return;
        }
        lastJumpTime = Time.time;
        isJumping = true;
        selfAnimator.SetBool("isJumping", true);
        selfCollider.isTrigger = true;
        selfOrderer.enabled = false;
        selfRenderer.sortingOrder = 32767;
    }

    public void Land() {
        isJumping = false;
        selfAnimator.SetBool("isJumping", false);
        selfCollider.isTrigger = false;
        selfOrderer.enabled = true;
    }

    private void Update() {
        if (isJumping) {
            selfRenderer.sortingOrder = 32767;
            if (Time.time - lastJumpTime > duration) {
                Land();
            }
        }
    }
}
