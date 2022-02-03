using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stat")]
public class Stat : ScriptableObject
{
    [SerializeField]
    public float baseValue;

    public virtual float GetValue() {
        return baseValue;
    }
}
