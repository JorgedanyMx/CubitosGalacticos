using UnityEngine;

public class s_SubjectMovement : MonoBehaviour
{

    [SerializeField] GameObject subject;
    
    [SerializeField] GameObject initialPosition;
    [SerializeField] GameObject finalPosition;
    [SerializeField] float velocity;
    Vector3 targetPosition;

    void Start()
    {
        subject.transform.position = initialPosition.transform.position;
        targetPosition = initialPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        subject.transform.position = Vector3.Lerp(subject.transform.position, targetPosition, Time.deltaTime * velocity);
    }

    public void MoveSubject()
    {
        
            targetPosition = finalPosition.transform.position;
        
    }

    public void RestartSubject() //LLamado por evento
    {
            subject.transform.position = initialPosition.transform.position;
            //targetPosition = initialPosition.transform.position;
    }
}
