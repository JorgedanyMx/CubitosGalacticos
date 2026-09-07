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
        slide.position = new Vector3 (slide.transform.position.x, slide.transform.position.y, (target.z < min.position.z? min.position.z : target.z) > max.position.z? max.position.z : target.z);
        finalPosition = slide.position;
        Debug.Log(finalPosition);
    }

    void p_ISlider.ShouldMove(Vector3 target)
    {
        Debug.Log("hit" + target);
        ShouldMove(target);
    }
}

