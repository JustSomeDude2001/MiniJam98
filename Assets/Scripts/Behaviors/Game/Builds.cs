using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builds : MonoBehaviour
{
    public float buildingCooldown;

    public Animator selfAnimator;

    public AudioSource audioSource;
    public AudioClip onFailSound;
    public CursorTracker cursorTracker;
    
    [HideInInspector]
    public bool isInRadius = false;

    private void Start() {
        if (selfAnimator == null)
            selfAnimator = GetComponent<Animator>();
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        if (cursorTracker == null)
            cursorTracker = GetComponent<CursorTracker>();
    }

    /// <summary>
    /// Check if can build on gameObject's cell.
    /// </summary>
    /// <returns></returns>
    public bool CanBuild(int cost) {
        if (!isInRadius) {
            return false;
        }
        if (Player.isOnPause) {
            return false;
        }
        if (Time.time - lastBuild <= buildingCooldown) {
            return false;
        }
        if (Player.money < cost) {
            return false;
        }
        GameObject targetObject = GridMatrix.GetObject(GridMatrix.selfGrid.WorldToCell(transform.position));
        
        if (targetObject == null) {
            return true;
        } else {
            return false;
        }
    }

    [HideInInspector]
    public float lastBuild = -1;

    public int curCost = 1;
    
    public void BuildSpecific(GameObject building)
    {
        curCost = 1;
        if (CanBuild(curCost)) {
            var newBuilding = Instantiate(building, transform.position, Quaternion.identity);
            Player.money -= curCost;
            lastBuild = Time.time;
        }
        else if (!cursorTracker.isOutOfBounds)
        {
            // Preventing obnoxious beeping non-stop.                       
            if (Time.time - lastBuild <= buildingCooldown) {
                return;
            }
            audioSource.clip = onFailSound; 
            audioSource.Play();
        }
    }
}
