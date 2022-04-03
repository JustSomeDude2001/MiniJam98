using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DelayedFlashSpawn : MonoBehaviour
{
    public Animator animator;
    public Light2D light;
    public Movable movable;
    public Destructible destructible;
    public float duration;
    public float maxFlashIntensity;

    private float remainingTime;

    private void OnEnable()
    {
        remainingTime = duration;
        
        light.intensity = 0;
        transform.DOScale(Vector3.zero, 0);
        transform.DOScale(Vector3.one, duration);
        
        movable.noMovementTime = duration;
        destructible.invincibilityTime = duration;

        animator.enabled = false;
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            light.intensity = 0;
            animator.enabled = true;
            return;
        }

        if (remainingTime / duration < 0.5)
        {
            light.intensity = remainingTime / duration * maxFlashIntensity;
        }
        else
        {
            light.intensity = (1 - remainingTime / duration) * maxFlashIntensity;
        }
        
    }
}
