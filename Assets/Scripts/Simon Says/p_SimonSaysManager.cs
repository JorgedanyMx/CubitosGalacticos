using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;

public class p_SimonSaysManager : MonoBehaviour
{
    [SerializeField] private p_ClickInputHandler playerInput;
    List<int> current;
    public int numAmount = 2;
    bool correct = false;
    public string stream;

    Dictionary<int, string> numberToColor = new Dictionary<int, string>
    {
        {1, "amarillo"},
        {2, "morado"},
        {3, "azul"},
        {4, "verde"}
    };
    public void GameStart()
    {
        numAmount = numAmount+2;
        current = new List<int>();
        for (int i = 0; i < numAmount; i++)
        {
            current.Add(UnityEngine.Random.Range(1, 4));
        }
        List<string> label = current.Select(n => numberToColor[n]).ToList();
        Debug.Log(string.Join(", ", current));
        stream=string.Join(", ", label);
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
