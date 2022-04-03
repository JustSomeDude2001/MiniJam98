using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

/// <summary>
/// Behavior for items that can take damage from attacks.
/// </summary>
public class Destructible : MonoBehaviour
{
    public Stat maxHealth;
    private int healthCurrent = 1;

    public float dyingTime = 1;
    public bool dying = false;

    public float invincibilityTime = 0;
    
    [HideInInspector]
    public float lastAuraDamageTime;
    Animator myAnimator;
    
    public AudioClip onCreateSound;
    public AudioClip onDestroySound;
    public AudioClip onDamagedSound;

    public AudioSource audioSource;
    
    public int GetMaxHealth() {
        return (int)maxHealth.GetValue();
    }

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        healthCurrent = (int)maxHealth.GetValue();

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void OnEnable()
    {
        if (audioSource == null)
        {
            return;
        }
        audioSource.clip = onCreateSound;
        audioSource.Play();
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
        if (healthCurrent <= 0)
        {
            if (audioSource != null) {
                audioSource.clip = onDestroySound;
                audioSource.Play();
            }
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
            if (CompareTag("Player")) {
                Player.isAlive = false;
            }
            dying = true;
        }
    }

    private void Update()
    {
        if (invincibilityTime > 0)
            invincibilityTime -= Time.deltaTime;
        if (dying == true) {
            dyingTime -= Time.deltaTime;
            if (dyingTime <= 0) {
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (invincibilityTime > 0)
            return;
        ClampHealth();
        if (audioSource != null)
        {
            Debug.Log("Inflicted Damage On" + this.name);
            audioSource.clip = onDamagedSound;
            audioSource.Play();
        }
        healthCurrent -= damage;
        ClampHealth();
    }

    public void Heal(int value) {
        ClampHealth();
        healthCurrent += value;
        ClampHealth();
    }

}
