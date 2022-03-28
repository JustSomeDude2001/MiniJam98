using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TogglesLight : MonoBehaviour
{
    public List<Light2D> lights;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
            for(int i = 0; i < lights.Count; i++) {
                lights[i].enabled = true;
            }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
            for(int i = 0; i < lights.Count; i++) {
                lights[i].enabled = false;
            }
    }
    
}