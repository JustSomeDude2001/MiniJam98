using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General tracker for player on the playing field.
/// </summary>
public class Player : MonoBehaviour
{
    public static float lastClick;
    public static Vector3 playerPos;
    /// <summary>
    /// Core money. Used for buying constructions.
    /// </summary>
    public static int money = 0;

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
