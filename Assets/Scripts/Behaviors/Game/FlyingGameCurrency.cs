using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

public class FlyingGameCurrency : MonoBehaviour
{
    private static Transform playerTransform;
    private static Transform metaCounterTransform;

    public bool approachesOnPickup;
    public float pickupRadius;
    
    public bool isMeta;

    public int value;

    public float velocity;

    public float delay;

    public Ease ease;

    public float minDistance;

    public AudioSource audioSource;
    public AudioClip onGainSound;

    public SpriteRenderer renderer;
    
    private bool startedMovement = false;

    private bool grantedPoints = false;
    
    private Tween movement;

    
    
    Vector3 getTarget()
    {
        if (isMeta)
        {
            return metaCounterTransform.position;
        }
        else
        {
            return playerTransform.position;
        }
    }

    private void grantPoints()
    {
        if (isMeta)
        {
            Player.metaMoney += value;
        }
        else
        {
            Player.money += value;
            Player.moneyAllTime += value;
        }

        audioSource.clip = onGainSound;
        audioSource.Play();
        renderer.enabled = false;
        grantedPoints = true;
    }
    
    void ApproachTarget()
    {
        var target = getTarget();
        var distance = (target - transform.position).magnitude;
        movement = transform.DOMove(target, distance / velocity).SetEase(ease);
    }
    
    private void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (metaCounterTransform == null)
        {
            metaCounterTransform = GameObject.FindGameObjectWithTag("MetaCounter").transform;
        }
    }

    private void Update()
    {
        if (grantedPoints)
        {
            if (audioSource.isPlaying)
            {
                return;
            }
            Destroy(gameObject);
            return;
        }
        
        if (startedMovement && !movement.active)
        {
            if ((transform.position - getTarget()).magnitude > minDistance)
            {
                ApproachTarget();
            }
            else
            {
                grantPoints();
            }
        }
        
        if (delay > 0 && !approachesOnPickup)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            if (!approachesOnPickup || (approachesOnPickup && (transform.position - playerTransform.position).magnitude < pickupRadius))
            {
                startedMovement = true;
                ApproachTarget();
            }
        }
    }
}
