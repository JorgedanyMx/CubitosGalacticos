using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class p_moveSlider : MonoBehaviour, p_ISlider
{   
    public int currentPosition = 0;
    public int maxPosition = 6;
    [SerializeField] private Transform min;
    [SerializeField] private Transform max;
    public Vector3[] position;

    void Start()
    {
        position = new Vector3[maxPosition+1];
        Vector3 div = (max.position - min.position) / maxPosition;
        for (int i = 0; i < maxPosition+1;i++)
        {
            position[i] = min.position + (div*i);
        }

        gameObject.transform.position = position[0];
    }

    void ShouldMove()
    {
        currentPosition = currentPosition+1 > maxPosition? currentPosition = 0: currentPosition+1;
        gameObject.transform.position = position[currentPosition];
    }

    void p_ISlider.ShouldMove()
    {
        ShouldMove();
    }
}

