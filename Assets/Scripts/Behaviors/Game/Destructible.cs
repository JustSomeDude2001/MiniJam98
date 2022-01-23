using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behavior for items that can take damage from attacks.
/// </summary>
public class Destructible : MonoBehaviour
{
    private int healthCurrent = 1;

    /// <summary>
    /// Maximum health can be safely modified as needed - clamping to
    /// prevent immortality or the like is done in methods concerning
    /// current health.
    /// </summary>
    public int healthMax = 1;

    private void Start() {
        if (tag == "Wall") {
            healthMax = (int)(healthMax * Player.GetModifier("wallHealth"));
        }
        healthCurrent = healthMax;
    }

    public int GetHealth() {
        return healthCurrent;
    }

    /// <summary>
    /// Used to prevent health overflow and track when to kill object.
    /// </summary>
    private void ClampHealth() {
        if (healthCurrent > healthMax) {
            healthCurrent = healthMax;
        }
        if (healthCurrent <= 0) {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) {
        ClampHealth();
        healthCurrent -= damage;
        ClampHealth();
    }

    public void Heal(int value) {
        ClampHealth();
        healthCurrent += value;
        ClampHealth();
    }
}
