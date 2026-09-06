using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class p_dialHandler : MonoBehaviour, p_IDial
{
    public int currentPosition = 0;
    public int maxPosition = 6;
    [SerializeField] private Transform min;
    [SerializeField] private Transform max;
    public Quaternion[] rotation;

    void Start()
    {
        rotation = new Quaternion[maxPosition+1];
        for (int i = 0; i < maxPosition+1; i++)
        {
            float t = (float)i / maxPosition;
            rotation[i] = Quaternion.Slerp(min.rotation, max.rotation, t);
        }

        gameObject.transform.rotation = rotation[0];
    }

    void ShouldMove()
    {
        currentPosition = currentPosition+1 > maxPosition? currentPosition = 0: currentPosition+1;
        gameObject.transform.rotation = rotation[currentPosition];
    }

    void p_IDial.ShouldMove()
    {
        ShouldMove();
    }
}
