using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnGrid : MonoBehaviour
{

    public Vector3Int gridPos;

    void Start()
    {
        Vector3Int gridPos = CursorTracker.selfGrid.WorldToCell(transform.position);
        GridMatrix.Build(gridPos, gameObject);
    }

    private void OnDestroy() {
        GridMatrix.Destroy(gridPos);
    }
}
