using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class p_SimonSaysManager : MonoBehaviour
{
    [SerializeField] GameEvent SimonEvent;
    [SerializeField] private p_ClickInputHandler playerInput;
    List<int> current;
    public int numAmount = 2;
    bool correct = false;
    public void GameStart()
    {
        numAmount = numAmount+2;
        current = new List<int>();
        for (int i = 0; i < numAmount; i++)
        {
            current.Add(UnityEngine.Random.Range(1, 4));
        }
        Debug.Log(string.Join(", ", current));
    }

    public void CheckPlayerChoice(List<int> choice)
    {   
        if (choice.SequenceEqual(current))
        {
            // las dos listas son iguales
            Debug.Log("Yessir Simon");
            correct = true;
        }
        else
            Debug.Log("NAH Simon");
    }
}
