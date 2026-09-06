using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class p_moveSlider : MonoBehaviour, p_ISlider
{   
    public int currentPosition = 0;
    public int maxPosition = 6;
    public Transform min;
    public Transform max;
    [SerializeField] private Transform slide;
    public Vector3[] position;
    public Vector3 finalPosition;

    void Start()
    {
        // gameObject.transform.position = position[0];
    }

    void ShouldMove(Vector3 target)
    {
        slide.position = new Vector3 ((target.x < min.position.x? min.position.x : target.x) > max.position.x? max.position.x : target.x, gameObject.transform.position.y, gameObject.transform.position.z);
        finalPosition = slide.position;
    }

    void p_ISlider.ShouldMove(Vector3 target)
    {
        ShouldMove(target);
    }
}

