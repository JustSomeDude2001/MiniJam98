using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A behavior for items that damage on contact.
/// </summary>
public class Damages : MonoBehaviour
{
    public int damageOnContact = 1;

    [Tooltip("Add tags that will be ignored on contact")]
    public List<string> damageBlacklist;

    [Tooltip("Cooldown until damage on contact can be taken again")]
    public float cooldown = 1;

    float lastTime = -1;

    [Tooltip("Leave empty if you want gameObject's animator to be chosen by default.")]
    public Animator targetAnimator;

    private void Start() {
        if (targetAnimator == null)
            targetAnimator = GetComponent<Animator>();
        if (tag == "Wall") {
            damageOnContact = (int)((float)damageOnContact *  Player.GetModifier("wallDamage"));
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (damageBlacklist.Contains(other.gameObject.tag)) {
            return;
        }
        
        Destructible target = other.gameObject.GetComponent<Destructible>();
        if (target == null) {
            return;
        }
        
        if (Time.time - lastTime > cooldown) {
            targetAnimator.SetBool("isAttacking", true);
            target.TakeDamage(damageOnContact);
            lastTime = Time.time;
            //Debug.Log("Damage Inflicted");
        }

    }



    /// <summary>
    /// This is used to allow for aura damage.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other) {
        if (damageBlacklist.Contains(other.gameObject.tag)) {
            return;
        }
        
        Destructible target = other.gameObject.GetComponent<Destructible>();
        if (target == null) {
            return;
        }
            
        targetAnimator.SetBool("isAttacking", true);
        target.lastAuraDamageTime = Time.time;
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (damageBlacklist.Contains(other.gameObject.tag)) {
            return;
        }
        
        Destructible target = other.gameObject.GetComponent<Destructible>();
        if (target == null) {
            return;
        }
        
        if (Time.time - target.lastAuraDamageTime < cooldown) {
            return;
        }

        targetAnimator.SetBool("isAttacking", true);
        target.TakeDamage(damageOnContact);
        lastTime = Time.time;
        target.lastAuraDamageTime = Time.time;
    }

    private void OnTriggerExit2D(Collider2D other) {
        targetAnimator.SetBool("isAttacking", false);
    }

    private void OnCollisionExit2D(Collision2D other) {
        targetAnimator.SetBool("isAttacking", false);
    }
}
