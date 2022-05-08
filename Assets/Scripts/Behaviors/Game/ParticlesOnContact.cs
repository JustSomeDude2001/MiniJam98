using System;
using UnityEngine;

public class ParticlesOnContact : MonoBehaviour
{
    public ParticleSystem particles;

    private void OnTriggerEnter2D(Collider2D col)
    {
        particles.Play();
    }
}
