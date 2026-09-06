using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class p_ClickInputHandler : MonoBehaviour
{
    public p_MousePosition MousePos;
    public InputAction IA_MouseClick;
    public Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        IA_MouseClick = InputSystem.actions.FindAction("MouseClick");
        IA_MouseClick.Enable();
        IA_MouseClick.started += OnMouseClick;
    }

    private void OnMouseClick(InputAction.CallbackContext context)
    {

        Ray ray = cam.ScreenPointToRay(MousePos.pos);
        // Debug.Log("Creating Ray");
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Starting Ray");
            if (hit.collider.TryGetComponent<p_IButton>(out p_IButton component))
            {
                ButtonPressed(component.Clicked());
                // Debug.Log("Button Pressed");
            }
        }
    }
    public List<int> playerList;
    public void ButtonPressed(int input)
    {
        playerList.Add(input);
        // foreach (int num in playerList)
        //     Debug.Log(num);
    }

    // OnTimeEnd or OnGameEnd
    // playerList
}
