using NUnit.Framework;
using UnityEngine;

public class s_MirrorMovement : MonoBehaviour
{

    [SerializeField] GameObject mirror;
    
    [SerializeField] GameObject topPosition;
    [SerializeField] GameObject downPosition;
    [SerializeField] float velocity;
    Vector3 targetPosition;


    private bool isActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isActive = false;       
    }

    // Update is called once per frame
    void Update()
    {
        mirror.transform.position = Vector3.Lerp(mirror.transform.position, targetPosition, Time.deltaTime * velocity);
    }

    public void MirrorActive()
    {
        if(isActive == false)
        {
            targetPosition = downPosition.transform.position;
            isActive = true;
        }
        else
        {
            targetPosition = topPosition.transform.position;
            isActive = false;
        }
    }
}
