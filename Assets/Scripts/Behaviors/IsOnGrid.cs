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
        Debug.Log(GridMatrix.GetObject(gridPos).ToString());
    }

    private void OnDestroy() {
        if (GridMatrix.GetObject(gridPos) == gameObject)
            GridMatrix.Destroy(gridPos);
    }
}
