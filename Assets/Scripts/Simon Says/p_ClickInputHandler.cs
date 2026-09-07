using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class p_ClickInputHandler : MonoBehaviour
{
    private p_SimonSaysManager manager;
    public p_MousePosition MousePos;
    private InputAction IA_MouseClick;
    
    public Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        manager = FindFirstObjectByType<p_SimonSaysManager>();
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
            if (hit.collider.TryGetComponent<p_IButton>(out p_IButton button))
            {
                ButtonPressed(button.Clicked());
                // Debug.Log("Button Pressed");
            }
            if (hit.collider.TryGetComponent<p_ISlider>(out p_ISlider slider))
            {
                slider.ShouldMove(hit.point);
            }
            if (hit.collider.TryGetComponent<p_IDial>(out p_IDial dial))
            {
                dial.ShouldMove();
            }
            
        }
    }
    public List<int> playerList;
    public void ButtonPressed(int input)
    {
        if (playerList.Count == manager.numAmount)
            return; // ReturnPlayerList();
        playerList.Add(input);
        // foreach (int num in playerList)
        //     Debug.Log(num);
        
    }
    // OnTimeEnd or OnGameEnd
    // playerList
    public void ReturnPlayerList()
    {
        manager.CheckPlayerChoice(playerList);
        playerList.Clear();
    }
}
