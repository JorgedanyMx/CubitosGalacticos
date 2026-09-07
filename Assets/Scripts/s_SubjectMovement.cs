using NUnit.Framework;
using UnityEngine;

public class s_SubjectMovement : MonoBehaviour
{

    [SerializeField] GameObject subject;
    
    [SerializeField] GameObject initialPosition;
    [SerializeField] GameObject finalPosition;
    [SerializeField] float velocity;
    [SerializeField] private float rotationVelocity = 180f;

    Vector3 targetPosition;

    bool isMoving;
    bool isRotating;


    void Start()
    {
        RestartSubject();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            MoveTowardsTarget();
        }

        if(isRotating)
        {
            RotateTowardsCamera();
        }
    }

    public void MoveSubject()
    {
        
        targetPosition = finalPosition.transform.position;
        isMoving = true;
        isRotating = false;
    }

    public void RestartSubject() //LLamado por evento
    {
            subject.transform.position = initialPosition.transform.position;
            subject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            targetPosition = initialPosition.transform.position;

            isMoving = false;
            isRotating = false;
            
    }

    private void MoveTowardsTarget()
    {
        subject.transform.position = Vector3.Lerp(
            subject.transform.position,
            targetPosition,
            Time.deltaTime * velocity
        );

        // Revisamos si está suficientemente cerca
        if (Vector3.Distance(subject.transform.position, targetPosition) < 0.01f)
        {
            // Aseguramos que quede exactamente en el destino
            subject.transform.position = targetPosition;

            isMoving = false;
            isRotating = true;
        }
    }

    private void RotateTowardsCamera()
    {
        if (Camera.main == null)
        {
            return;
        }

        Vector3 direction =
            Camera.main.transform.position - subject.transform.position;

        // Evita que el personaje se incline
        direction.y = 0f;

        if (direction.sqrMagnitude < 0.001f)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        subject.transform.rotation = Quaternion.RotateTowards(
            subject.transform.rotation,
            targetRotation,
            rotationVelocity * Time.deltaTime
        );

        // Cuando termina el giro, dejamos de actualizarlo
        if (Quaternion.Angle(subject.transform.rotation, targetRotation) < 0.5f)
        {
            subject.transform.rotation = targetRotation;
            isRotating = false;

            Debug.Log("Terminó de mirar hacia la cámara");
        }
    }
    
}
