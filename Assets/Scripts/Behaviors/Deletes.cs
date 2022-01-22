using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletes : MonoBehaviour
{
    public void Delete() {
        GridMatrix.Destroy(CursorTracker.cursorPos);
    }
}
