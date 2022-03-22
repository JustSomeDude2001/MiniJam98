using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadsScene : MonoBehaviour
{
    public string sceneName;
    public bool started = false;
    public float waitTime = 0;
    public bool isPortal = false;
    public AudioSource audioSource;
    public AudioClip onLoadSound;
    
    public void Load()
    {
        audioSource.clip = onLoadSound;
        audioSource.Play();
        started = true;
    }

    private void Update() {
        if (started) {
            waitTime -= Time.deltaTime;
            if (waitTime < 0) {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (isPortal) {
            Load();
        }
    }
}
