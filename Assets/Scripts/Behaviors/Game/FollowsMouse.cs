using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowsMouse : MonoBehaviour
{
    // Update is called once per frame
    public Camera mainCam;
    void Update()
    {
        var mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;
        transform.position = mousePos;
    }
}
