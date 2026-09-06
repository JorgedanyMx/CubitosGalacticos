using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class p_SimonSaysManager : MonoBehaviour
{
    [SerializeField] private p_ClickInputHandler playerInput;
    List<int> current;
    void GameStart(int numAmount)
    {
        current = new List<int>();
        for (int i = 0; i < numAmount; i++)
        {
            current.Add(UnityEngine.Random.Range(1, 4));
        }
    }

    private void CheckPlayerChoice(List<int> choice)
    {
        if (choice.SequenceEqual(current))
        {
            // las dos listas son iguales
            Debug.Log("Yessir");
        }
    }
}
