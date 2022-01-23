using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes item snap to cursor, while staying on grid.
/// </summary>
public class SnapsToCursor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = GridMatrix.selfGrid.CellToWorld(CursorTracker.cursorPos) + 
                             GridMatrix.selfGrid.cellSize / 2f;
    }
}
