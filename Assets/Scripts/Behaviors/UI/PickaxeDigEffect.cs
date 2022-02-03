using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeDigEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem DigEffect;

    public void Dig()
    {
        DigEffect.Play();
    }
}