using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public bool _cursorInvisible = true;
    void Update()
    {
        if (_cursorInvisible)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _cursorInvisible = false;
            }
        }
        else if (_cursorInvisible == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _cursorInvisible = true;
            }
        }
    }
}
