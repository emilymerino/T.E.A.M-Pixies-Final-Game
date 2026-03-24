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
        transform.position = Input.mousePosition; // correct for UI
    }
}