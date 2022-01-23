using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builds : MonoBehaviour
{
    public GameObject building;
    public int cost;

    /// <summary>
    /// Check if can build on gameObject's cell.
    /// </summary>
    /// <returns></returns>
    public bool CanBuild() {
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

    public void Build() {
        if (CanBuild()) {
            GridMatrix.Build(GridMatrix.selfGrid.WorldToCell(transform.position), 
                             Instantiate(building, transform.position, Quaternion.identity));
            Player.money -= cost;
        }
    }
}
