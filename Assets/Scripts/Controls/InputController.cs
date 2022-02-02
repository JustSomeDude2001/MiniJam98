using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    Movable myMovable;

    private void Start()
    {
        myMovable = GetComponent<Movable>();
        myMovable.direction = Vector2.zero;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        myMovable.direction = context.ReadValue<Vector2>();
        
    }
}