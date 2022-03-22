using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A behavior for items that damage on contact.
/// </summary>
public class Damages : MonoBehaviour
{
    public Stat damage;
    [Tooltip("Add tags that will be ignored on contact")]
    public List<string> damageBlacklist;

    [Tooltip("Cooldown until damage on contact can be taken again")]
    public float cooldown = 1;

    [HideInInspector]
    public float lastAttackTime = -1;

    [Tooltip("Leave empty if you want gameObject's animator to be chosen by default.")]
    public Animator targetAnimator;

    public bool isAuraDamage = false;
    
    bool CanDamage(GameObject target) {
        if (target == null) {
            return false;
        }
        if (Time.time - lastAttackTime < cooldown && !isAuraDamage) {
            return false;
        }

        Destructible targetDest = target.GetComponent<Destructible>();
        if (isAuraDamage && Time.time - targetDest.lastAuraDamageTime < cooldown)
        {
            return false;
        }
        return !(damageBlacklist.Contains(target.tag));
    }

    void InflictDamage(Destructible target) {
        if (target == null) {
            return;
        }
        if (targetAnimator != null)
            targetAnimator.SetBool("isAttacking", true);
        target.TakeDamage(GetDamage());
        lastAttackTime = Time.time;
    }

    private void Start() {
        if (targetAnimator == null)
            targetAnimator = GetComponent<Animator>();
    }

    public int GetDamage() {
        return (int)damage.GetValue();
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (!CanDamage(other.gameObject)) {
            return;
        }
        
        Destructible target = other.gameObject.GetComponent<Destructible>();

        if (target == null) {
            return;
        }
        
        InflictDamage(target);
    }



    /// <summary>
    /// This is used to allow for aura damage.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other) {
        Destructible target = other.gameObject.GetComponent<Destructible>();

        if (target == null) {
            return;
        }
        
        if (targetAnimator != null)
            targetAnimator.SetBool("isAttacking", true);
        target.lastAuraDamageTime = Time.time;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (!CanDamage(other.gameObject)) {
            return;
        }
        
        Destructible target = other.gameObject.GetComponent<Destructible>();

        if (target == null) {
            return;
        }

        InflictDamage(target);

        target.lastAuraDamageTime = Time.time;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (targetAnimator != null)
            targetAnimator.SetBool("isAttacking", false);
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (targetAnimator != null)
            targetAnimator.SetBool("isAttacking", false);
    }
}
