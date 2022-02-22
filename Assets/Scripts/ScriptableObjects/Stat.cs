using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stat")]
public class Stat : ScriptableObject
{
    [Tooltip("This is the base value of the stat when unapgraded.")]
    public float baseValue;

    public virtual float GetValue() {
        return baseValue;
    }
}
