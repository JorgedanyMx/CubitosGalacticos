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
        if (min.position.z> max.position.z)
        {
            Transform tmptransform=min;
            min = max;
            max = tmptransform;
        }
    }

    void ShouldMove(Vector3 target)
    {
        Debug.Log("Cursor: " + target.z);
        float tmpZtarget = target.z;
        if(tmpZtarget<min.position.z || tmpZtarget > max.position.z)
        {
            return;
        }
        slide.position = new Vector3 (slide.transform.position.x, slide.transform.position.y, tmpZtarget);
        finalPosition = slide.position;
        Debug.Log(finalPosition);
        Debug.Log("Final: " + finalPosition.z);
    }

    void p_ISlider.ShouldMove(Vector3 target)
    {
        Debug.Log("hit" + target);
        ShouldMove(target);
    }
}

