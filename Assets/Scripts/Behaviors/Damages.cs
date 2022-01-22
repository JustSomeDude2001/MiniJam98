using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages : MonoBehaviour
{
    public int damageOnContact = 1;

    [Tooltip("Add tags that will be ignored on contact")]
    public List<string> damageBlacklist;

    [Tooltip("Cooldown until damage on contact can be taken again")]
    public float cooldown = 1;

    float lastTime = -1;
    private void OnCollisionStay2D(Collision2D other) {
        if (damageBlacklist.Contains(other.gameObject.tag)) {
            return;
        }
        Destructible target = other.gameObject.GetComponent<Destructible>();
        if (target == null) {
            return;
        }
        
        if (Time.time - lastTime > cooldown) {
            target.TakeDamage(damageOnContact);
            lastTime = Time.time;
            Debug.Log("Damage Inflicted");
        }

    }
}
