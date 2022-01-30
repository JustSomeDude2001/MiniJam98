using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiesAfterFirstAttack : MonoBehaviour
{
    Destructible destructible;
    
    [Tooltip("Leave empty if you want gameObject's Damage component to be used")]
    public Damages damager;
    void Start()
    {
        if (damager == null) 
            damager = GetComponent<Damages>();
        destructible = GetComponent<Destructible>();
    }

    void Update()
    {
        if (damager.lastAttackTime > 0) {
            destructible.TakeDamage(destructible.healthMax);
        }    
    }
}
