using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    public float speedPlayer = 1;
    public float speedDig = 1;
    public float radiusToDig = 1;
    public float radiusBuild = 1;
    public int healthPlayer = 1;

    Movable selfMovable;
    private void Start() {
        selfMovable = GetComponent<Movable>();
        if (selfMovable == null) {
            selfMovable = gameObject.AddComponent<Movable>();
        }
        selfMovable.speed = speedPlayer;
    }

    private void Update() {
        selfMovable.speed = speedPlayer;
    }
}
