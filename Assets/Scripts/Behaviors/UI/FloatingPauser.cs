using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPauser : MonoBehaviour
{
    public List<SineObjectFloater> floaters;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
            for(int i = 0; i < floaters.Count; i++) {
                floaters[i].paused = true;
            }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
            for(int i = 0; i < floaters.Count; i++) {
                floaters[i].paused = false;
            }
    }
    
}
