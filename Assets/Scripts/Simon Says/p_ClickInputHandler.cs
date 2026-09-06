using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class p_ClickInputHandler : MonoBehaviour
{
    [SerializeField] p_ISlider slider;
    public p_MousePosition MousePos;
    public InputAction IA_MouseClick;
    
    public Camera cam;
    public bool sliderSelected;
    p_ISlider temp_slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        IA_MouseClick = InputSystem.actions.FindAction("MouseClick");
        IA_MouseClick.Enable();
        IA_MouseClick.started += OnMouseClick;
        IA_MouseClick.performed += OnMouseHold;
        IA_MouseClick.canceled += OnMouseRelease;
    }

    private void OnMouseRelease(InputAction.CallbackContext context)
    {
        sliderSelected = false;
        Cursor.visible = true;
        // IA_MouseDelta.Disable();
        if (temp_slider != null)
        {
            temp_slider.ShouldMove(false);
        }
    }

    private void OnMouseHold(InputAction.CallbackContext context)
    {
        Ray ray = cam.ScreenPointToRay(MousePos.pos);
        // Debug.Log("Creating Ray");
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent<p_ISlider>(out p_ISlider slider) && sliderSelected == false)
            {
                sliderSelected = true;
                Cursor.visible = false;
                slider.ShouldMove(true);
                temp_slider = slider;
            }
        }
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
