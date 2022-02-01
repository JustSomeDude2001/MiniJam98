using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PausesOnKey : MonoBehaviour
{
    public string pauseScene;

    public void OnTogglePause(InputAction.CallbackContext context) {
        if (context.started != true) {
            return;
        }
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync(pauseScene);
            Player.isOnPause = false;
        } else {
            Time.timeScale = 0;
            SceneManager.LoadScene(pauseScene, LoadSceneMode.Additive);
            Player.isOnPause = true;
        }
    }
    
}
