using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class p_MousePosition : MonoBehaviour
{
    InputAction mousePos;
    public Vector2 pos;

    void OnEnable()
    {
        mousePos = InputSystem.actions.FindAction("MousePosition");
        mousePos.Enable();
        mousePos.performed += OnUpdatedMouse;
    }

    private void OnUpdatedMouse(InputAction.CallbackContext context)
    {
        pos = context.ReadValue<Vector2>();
        // Debug.Log("Mouse is in " + pos);
    }
}
