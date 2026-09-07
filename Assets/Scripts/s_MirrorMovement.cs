using NUnit.Framework;
using UnityEngine;

public class s_MirrorMovement : MonoBehaviour
{

    [SerializeField] GameObject mirror;
    
    [SerializeField] GameObject topPosition;
    [SerializeField] GameObject downPosition;
    [SerializeField] float velocity;
    Vector3 targetPosition;

    void Start()
    {
        targetPosition = topPosition.transform.position;
        Debug.Log("Mirror Position: " +mirror.transform.position );
        Debug.Log("Top Position: " +topPosition.transform.position );
        
        //mirror.transform.position = downPosition.transform.position;
        Debug.Log("Final Position: " +mirror.transform.position );
    }

    // Update is called once per frame
    void Update()
    {
        mirror.transform.position = Vector3.Lerp(mirror.transform.position, targetPosition, Time.deltaTime * velocity);
    }

    public void DownMirror()
    {
        
            targetPosition = downPosition.transform.position;
        
    }

    public void UpMirror()
    {
            targetPosition = topPosition.transform.position;
    }
}
