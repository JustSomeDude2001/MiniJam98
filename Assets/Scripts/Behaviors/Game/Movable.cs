using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Give this to object that move by themselves.
/// </summary>
public class Movable : MonoBehaviour
{
    public string modifierName;
    public Vector2 direction = Vector2.zero;

    public float speed = 1;

    Rigidbody2D selfRigidBody;
    Animator selfAnimator;
    [SerializeField] private ParticleSystem Dust;

    private void Start()
    {
        selfRigidBody = GetComponent<Rigidbody2D>();
        selfAnimator = GetComponent<Animator>();
    }

    public float GetSpeed()
    {
        return speed * Player.GetModifier(modifierName) * Player.GetModifier(Player.ToTemp(modifierName));
    }

    private void Update()
    {
        float currentSpeed = GetSpeed();
        var newVelocity = direction * currentSpeed;
        selfRigidBody.velocity = newVelocity;
        if (tag == "Player")
        {
            selfAnimator.SetBool("isIdle", !(newVelocity.sqrMagnitude > 0));
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
}