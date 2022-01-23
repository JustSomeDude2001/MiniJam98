using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Property for upgradeable items.
/// </summary>
public class Upgradeable : MonoBehaviour
{
    /// <summary>
    /// Used to give time for animation to play
    /// + prevent immediate build and upgrade afterwards.
    /// </summary>
    public float timeUntilCanUpgrade;
    public GameObject nextUpgrade;
    public int cost;

    private void Update() {
        if (timeUntilCanUpgrade > 0)  {
            timeUntilCanUpgrade -= Time.deltaTime;
        }
    }
}
