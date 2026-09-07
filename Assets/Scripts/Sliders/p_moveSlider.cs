using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class p_moveSlider : MonoBehaviour, p_ISlider
{   
    public int currentPosition = 0;
    public const int maxPosition = 2; // 0 = min, 1 = mid, 2 = max
    public Transform min;
    public Transform mid;
    public Transform max;
    [SerializeField] private Transform slide;
    public Vector3[] position;
    public Vector3 finalPosition;

    void Start()
    {
        position = new Vector3[]
        {
            min.position,
            mid.position,
            max.position,
        };

        slide.position = position[0];
        finalPosition = slide.position;
    }

    void ShouldMove(Vector3 target)
    {
        currentPosition = currentPosition + 1 > maxPosition ? 0 : currentPosition + 1;
        slide.position = position[currentPosition];
        finalPosition = slide.position;
    }

    void p_ISlider.ShouldMove(Vector3 target)
    {
        ShouldMove(target);
    }
}

