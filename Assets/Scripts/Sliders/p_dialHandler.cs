using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class p_dialHandler : MonoBehaviour, p_IDial
{
    public int currentPosition = 1;
    public int maxPosition = 6;
    [SerializeField] private Transform min;
    [SerializeField] private Transform max;
    public Quaternion[] rotation;
    bool isBlocked=false;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rotation = new Quaternion[maxPosition+1];
        for (int i = 1; i < maxPosition+1; i++)
        {
            float t = (float)i / maxPosition;
            rotation[i] = Quaternion.Slerp(min.rotation, max.rotation, t);
        }
        gameObject.transform.rotation = rotation[0];
    }

    void ShouldMove()
    {
        currentPosition = currentPosition+1 > maxPosition? currentPosition = 1: currentPosition+1;
        gameObject.transform.rotation = rotation[currentPosition];
    }

    void p_IDial.ShouldMove()
    {
        if (!isBlocked)
        {
            ShouldMove();
            if (audioSource != null) 
            {
                float randomP = UnityEngine.Random.Range(0f, .2f);
                audioSource.pitch = .9f + randomP;
                audioSource.Play();
                //Debug.Log("Se llama al audio");
            }
        }
    }
    public void BlockDial()
    {
        isBlocked = true;
    }
    public void UnblockDial()
    {
        isBlocked=false;
    }
}
