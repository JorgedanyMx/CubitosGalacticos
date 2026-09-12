using UnityEngine;

public class s_CameraPosition : MonoBehaviour
{

    [SerializeField] GameObject initialPosition;
    [SerializeField] GameObject gamePosition;
    [SerializeField] GameData gameStatus;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = initialPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraMovement()
    {
        if(gameStatus.gameStates == GameStates.Minijuego)
        {
            
        }
    }
}
