using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachesObject : MonoBehaviour
{
    Movable selfMovable;

    public GameObject target;

    private void Start() {
        selfMovable = GetComponent<Movable>();
    }

    private void Update() {
        if (target == null) {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();

        selfMovable.direction = direction;
    }
}
