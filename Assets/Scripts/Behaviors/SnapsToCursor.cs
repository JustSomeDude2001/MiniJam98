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
        transform.position = CursorTracker.selfGrid.CellToWorld(CursorTracker.cursorPos) + 
                             CursorTracker.selfGrid.cellSize / 2f;
    }
}
