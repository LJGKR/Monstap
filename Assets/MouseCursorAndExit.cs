using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorAndExit : MonoBehaviour
{
    private bool isCursorLocked = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCursorLocked = !isCursorLocked;
        }

        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
