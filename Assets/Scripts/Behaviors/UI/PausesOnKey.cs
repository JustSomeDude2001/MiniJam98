using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PausesOnKey : MonoBehaviour
{
    public void OnTogglePause(InputAction.CallbackContext context) {
        if (context.started != true) {
            return;
        }
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
        } else {
            Time.timeScale = 0;
        }
    }
    
}
