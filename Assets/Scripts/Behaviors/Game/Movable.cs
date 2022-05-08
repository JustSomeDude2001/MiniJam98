using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Give this to object that move by themselves.
/// </summary>
public class Movable : MonoBehaviour
{
    public Vector2 direction = Vector2.zero;

    public float noMovementTime = 0;
    
    public Stat speed;

    public float speed_variety = 0;
    
    private float speedMultiplier = 1;

    Rigidbody2D selfRigidBody;
    Animator selfAnimator;
    [SerializeField] private ParticleSystem Dust;

    private void Start()
    {
        if (speed_variety > 0)
        {
            speedMultiplier += Random.Range(-speed_variety, +speed_variety);
        }
        selfRigidBody = GetComponent<Rigidbody2D>();
        selfAnimator = GetComponent<Animator>();
    }

    public float GetSpeed()
    {
        if (noMovementTime > 0)
        {
            return 0;
        }
        return speed.GetValue() * speedMultiplier;
    }

    private void FixedUpdate()
    {
        if (noMovementTime > 0)
        {
            noMovementTime -= Time.fixedDeltaTime;
        }
        float currentSpeed = GetSpeed();
        var newVelocity = direction * currentSpeed;
        selfRigidBody.velocity = newVelocity;
        if (CompareTag("Player"))
        {
            selfAnimator.SetBool(IsIdle, !(newVelocity.sqrMagnitude > 0));
            if (newVelocity.sqrMagnitude > 0)
            {
                if (_previousVelocity == Vector2.zero)
                    Dust.Play();
            }
            else
            {
                Dust.Stop();
            }
        }

        _previousVelocity = newVelocity;
    }

    private Vector2 _previousVelocity = Vector2.zero;
    private static readonly int IsIdle = Animator.StringToHash("isIdle");
}