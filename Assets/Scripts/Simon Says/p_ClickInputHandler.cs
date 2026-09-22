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
    public GameData gameData;
    
    public Camera cam;

    private Vector3 ultimoPuntoImpacto;
    private bool hayImpacto = false;
    public List<int> playerList;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        manager = FindFirstObjectByType<p_SimonSaysManager>();          //Carga el manager, y el boton
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
            Debug.DrawRay(ray.origin, ray.direction*100, Color.green, 10.5f);

            //Debug.Log("Starting Ray");
            if (hit.collider.TryGetComponent<p_IButton>(out p_IButton button))
            {
                if (button.Clicked() > 0)
                {
                    ButtonPressed(button.Clicked());
                    // Debug.Log("Button Pressed");
                }
            }
            if (hit.collider.TryGetComponent<p_ISlider>(out p_ISlider slider))
            {
                hayImpacto = true;
                ultimoPuntoImpacto = hit.point;
                slider.ShouldMove(hit.point);
            }
            if (hit.collider.TryGetComponent<p_IDial>(out p_IDial dial))
            {
                dial.ShouldMove();
            }
        }
    }
    public void ButtonPressed(int input)
    {
        if (gameData.gameStates != GameStates.EnPrueba)
        {
            playerList.Clear();
            return;
        }
        playerList.Add(input);
        Debug.Log(input);
        if (playerList.Count == manager.numAmount)
        {
            ReturnPlayerList();
            return; 
        }  
        // foreach (int num in playerList)
        //     Debug.Log(num);
    }
    // OnTimeEnd or OnGameEnd
    // playerList
    public void ReturnPlayerList()
    {
        string debugS1="",debugS2="";
        foreach(int tmp in playerList)
        {
            debugS1 += tmp;
        }

        Debug.Log("Esta es la playerList: " + debugS1);
        manager.CheckPlayerChoice(playerList);
        playerList.Clear();
        debugS1 = "";
    }
    void OnDrawGizmos()
    {
        if (hayImpacto)
        {
            Gizmos.color = Color.red;
            // Dibuja una esfera en la posición del hit
            Gizmos.DrawSphere(ultimoPuntoImpacto, 0.015f);
        }
    }
}
