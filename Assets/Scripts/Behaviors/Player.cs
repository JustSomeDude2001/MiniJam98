using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Vector3 playerPos;

    private void Start() {
        playerPos = transform.position;
    }

    private void Update() {
        playerPos = transform.position;
    }

    private void OnDestroy() {
        Debug.Log("Player Died");
    }
}
