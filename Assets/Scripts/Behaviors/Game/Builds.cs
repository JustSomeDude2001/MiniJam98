using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builds : MonoBehaviour
{
    public float buildingCooldown;
    public GameObject building;
    public int cost;

    Animator selfAnimator;

    private void Start() {
        selfAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// Check if can build on gameObject's cell.
    /// </summary>
    /// <returns></returns>
    public bool CanBuild() {
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

    public void Build() {
        if (CanBuild()) {
            Instantiate(building, transform.position, Quaternion.identity);
            Player.money -= cost;
            lastBuild = Time.time;
        }
    }

    private void Update() {
        if (selfAnimator != null) {
            selfAnimator.SetBool("canBuild", CanBuild());
        }
    }
}
