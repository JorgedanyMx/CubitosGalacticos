using UnityEngine;

public class p_DialManager : MonoBehaviour
{
    private p_dialHandler dial;
    private int targetPosition;
    bool correct;

    private void Start()
    {
        dial = FindFirstObjectByType<p_dialHandler>();
    }

    public void OnMiniGameStart()
    {
        targetPosition = Random.Range(0, dial.maxPosition + 1);
        Debug.Log(targetPosition);
    }

    public void OnMiniGameEnd()
    {
        if (dial.currentPosition == targetPosition)
        {
            correct = true;
            Debug.Log("YUPPERS dial");
        }
        else
        {
            correct = false;
            Debug.Log("NOPE dial");
        }
    }
}
