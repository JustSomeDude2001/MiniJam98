using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behavior for items that can take damage from attacks.
/// </summary>
public class Destructible : MonoBehaviour
{
    public Stat maxHealth;
    private int healthCurrent = 1;

    public float dyingTime = 1;
    public bool dying = false;

    [HideInInspector]
    public float lastAuraDamageTime;
    Animator myAnimator;

    public int GetMaxHealth() {
        return (int)maxHealth.GetValue();
    }

    private void Start() {
        myAnimator = GetComponent<Animator>();
        healthCurrent = (int)maxHealth.GetValue();
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
        if (healthCurrent > GetMaxHealth()) {
            healthCurrent = GetMaxHealth();
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
            if (tag == "Player") {
                Player.isAlive = false;
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
