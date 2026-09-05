using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class p_moveSlider : MonoBehaviour
{
    float speed = 1;
    [SerializeField] Transform min;
    [SerializeField] Transform max;
    
    void BarMoving(int direction)
    {
        float step = speed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), 
            new Vector3 (math.clamp(gameObject.transform.position.x + direction, min.position.x, max.position.x), gameObject.transform.position.y, gameObject.transform.position.z), 
            step);
    }
}
