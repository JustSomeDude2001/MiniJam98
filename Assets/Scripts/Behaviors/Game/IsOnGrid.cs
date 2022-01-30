using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to attach gameObjects to grid and detach them
/// per requirement automatically
/// </summary>
public class IsOnGrid : MonoBehaviour
{

    public Vector3Int gridPos;

    void Start()
    {
        gridPos = GridMatrix.selfGrid.WorldToCell(transform.position);
        GridMatrix.Build(gridPos, gameObject);
        
    }

    /// <summary>
    /// Items that spawn after destruction tend to spawn on the next scene, hence
    /// we need to make sure they are properly deleted.
    /// </summary>
    private void Update() {
        if (GridMatrix.selfGrid == null) {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        if (GridMatrix.selfGrid == null) {
            return;
        }
        if (GridMatrix.GetObject(gridPos) == gameObject)
            GridMatrix.Destroy(gridPos);
    }
}
