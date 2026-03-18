using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false; // hide default cursor
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (Camera.main == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }
}
