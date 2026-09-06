using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class p_dialHandler : MonoBehaviour, p_ISlider
{
    public InputAction IA_MouseDelta;
    float speed = 25;
    float Mdelta;
    bool Move = false;
    bool move
    {
        get{ return Move; }
        set
        {
            Move = value;
            if (Move)
                IA_MouseDelta.Enable();
            else
                IA_MouseDelta.Disable();
        }
    }

    void OnEnable()
    {
        IA_MouseDelta = InputSystem.actions.FindAction("MouseDelta");
        IA_MouseDelta.Disable();
        IA_MouseDelta.performed += MouseDelta;
        IA_MouseDelta.canceled += CursorSet;
    }

    private void CursorSet(InputAction.CallbackContext context)
    {
        Mouse.current.WarpCursorPosition(Camera.main.worldToCameraMatrix.MultiplyPoint3x4(gameObject.transform.position));
        Debug.Log(gameObject.transform.position);
    }

    void DialRotating(float direction)
    {
        float step = speed * Time.deltaTime;
        // gameObject.transform.rotation = Mathf.Lerp(gameObject.transform.rotation, )
        
        // gameObject.transform.position = Vector3.MoveTowards(
        //     new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), 
        //     new Vector3 (math.clamp(gameObject.transform.position.y + direction, min.position.x, max.position.x), gameObject.transform.position.y, gameObject.transform.position.z), 
        //     step);
    }
    private void MouseDelta(InputAction.CallbackContext context)
    {
        Mdelta = (context.ReadValue<Vector2>().normalized).y * 2;
    }

    void p_ISlider.ShouldMove(bool value)
    {
        move = value;
    }

    void Update()
    {
        if (move)
        {
            float step = speed * Time.deltaTime;
            Vector3 currentEuler = gameObject.transform.localEulerAngles;
            Vector3 targetEuler = new Vector3(
                currentEuler.x,
                math.clamp(currentEuler.y + Mdelta * 8, -120, 240),
                currentEuler.z
            );
            gameObject.transform.localRotation = Quaternion.RotateTowards(
                Quaternion.Euler(currentEuler),
                Quaternion.Euler(targetEuler),
                step
            );
        }
    }
}
