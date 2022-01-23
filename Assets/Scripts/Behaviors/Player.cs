using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General tracker for player on the playing field.
/// </summary>
public class Player : MonoBehaviour
{
    public static bool isAlive;
    public static float lastClick;
    public static Vector3 playerPos;
    /// <summary>
    /// Core money. Used for buying constructions.
    /// </summary>
    public static int money = 0;

    private void Start() {
        isAlive = true;
        lastClick = 0.25f;
        playerPos = transform.position;
    }

    private void Update() {
        playerPos = transform.position;
    }

    private void OnDestroy() {
        isAlive = false;
        Debug.Log("Player Died");
    }
}
