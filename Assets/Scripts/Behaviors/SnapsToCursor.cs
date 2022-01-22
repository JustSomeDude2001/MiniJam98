using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapsToCursor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = CursorTracker.selfGrid.CellToWorld(CursorTracker.cursorPos) + 
                             CursorTracker.selfGrid.cellSize / 2f;
        
    }
}
