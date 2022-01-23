using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletes : MonoBehaviour
{
    public void Delete() {
        Destroy(GridMatrix.GetObject(CursorTracker.cursorPosReal));
    }
}
