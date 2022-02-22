using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriesToJump : MonoBehaviour
{
    Movable selfMovable;
    Jumps selfJumper;
    public GameObject target;

    Vector3 lastPosition;

    private void Start() {
        selfMovable = GetComponent<Movable>();
        lastPosition = transform.position;
        selfJumper = GetComponent<Jumps>();
    }

    private void Update() {
        if (target == null) {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        if (target == null) {
            return;
        }

        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();

        if ((transform.position - lastPosition).magnitude < selfMovable.GetSpeed() * Time.deltaTime) {
            selfJumper.Jump();
        }
        lastPosition = transform.position;
    }
}
