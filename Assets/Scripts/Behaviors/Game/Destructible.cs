using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behavior for items that can take damage from attacks.
/// </summary>
public class Destructible : MonoBehaviour
{
    private int healthCurrent = 1;

    public float dyingTime = 1;
    public bool dying = false;

    /// <summary>
    /// Maximum health can be safely modified as needed - clamping to
    /// prevent immortality or the like is done in methods concerning
    /// current health.
    /// </summary>
    public int healthMax = 1;
    [HideInInspector]
    public float lastAuraDamageTime;
    Animator myAnimator;

    private void Start() {
        myAnimator = GetComponent<Animator>();
        if (tag == "Wall") {
            healthMax = (int)(healthMax * Player.GetModifier("wallHealth"));
        }
        if (tag == "Player") {
            healthMax = (int)(healthMax * Player.GetModifier("playerHealth"));
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
        if (dying) {
            return;
        }
        if (healthCurrent > healthMax) {
            healthCurrent = healthMax;
        }
        if (healthCurrent <= 0) {
            if (myAnimator != null)
                myAnimator.SetBool("isDead", true);
            Movable mover = GetComponent<Movable>();
            if (mover != null) {
                mover.enabled = false;
            }
            Damages damager = GetComponent<Damages>();
            if (damager != null) {
                damager.enabled = false;
            }
            dying = true;
        }
    }

    private void FixedUpdate() {
        if (dying == true) {
            dyingTime -= Time.fixedDeltaTime;
            if (dyingTime <= 0) {
                Destroy(gameObject);
            }
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
