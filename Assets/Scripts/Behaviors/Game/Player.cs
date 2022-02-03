using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// General tracker for player on the playing field.
/// Also tracks general game state.
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// Allows for temporary upgrades to remember which game they were initiated on.
    /// </summary>
    public static int currentGame = 0;
    public static bool isOnPause = false;
    public static bool purchasedMetaUpgrade = false;
    public static bool isAlive;
    public static float lastClick;
    public static Vector3 playerPos;
    /// <summary>
    /// Core money. Used for buying constructions.
    /// </summary>
    public static int money = 0;
    public static int metaMoney = 1000;
    public static int moneyAllTime = 0;

    private void Start() {
        money = 0;
        moneyAllTime = 0;
        isAlive = true;
        lastClick = 0.25f;
        playerPos = transform.position;
    }

    private void Update() {
        playerPos = transform.position;
    }

    private void OnDestroy() {
        currentGame++;
        isAlive = false;
        LoadsScene loader = GetComponent<LoadsScene>();
        SceneManager.LoadScene(loader.sceneName, LoadSceneMode.Single);
    }
}
