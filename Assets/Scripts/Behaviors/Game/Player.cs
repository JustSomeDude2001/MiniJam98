using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public static int metaMoney = 0;

    public static SortedDictionary<string, float> modifiers = new SortedDictionary<string, float>();
    public static SortedDictionary<string, int> upgradeLevels = new SortedDictionary<string, int>();
    
    public static float GetModifier(string name) {
        if (!modifiers.ContainsKey(name)) {
            modifiers.Add(name, 1f);
        }
        return modifiers[name];
    }

    public static void SetModifier(string name, float value) {
        if (!modifiers.ContainsKey(name)) {
            modifiers.Add(name, 1f);
        }
        modifiers[name] = value;
    }

    public static int GetLevel(string name) {
        if (!upgradeLevels.ContainsKey(name)) {
            upgradeLevels.Add(name, 0);
        }
        return upgradeLevels[name];
    }

    public static void SetLevel(string name, int value) {
        if (!upgradeLevels.ContainsKey(name)) {
            upgradeLevels.Add(name, 0);
        }
        upgradeLevels[name] = value;
    }

    private void Start() {
        money = 0;
        isAlive = true;
        lastClick = 0.25f;
        playerPos = transform.position;
    }

    private void Update() {
        playerPos = transform.position;
    }

    private void OnDestroy() {
        isAlive = false;
        LoadsScene loader = GetComponent<LoadsScene>();
        SceneManager.LoadScene(loader.sceneName, LoadSceneMode.Single);
    }
}
