using UnityEngine;

public class p_DialManager : MonoBehaviour
{
    private p_dialHandler dial;
    public int targetPosition;
    bool correct;
    public GameEvent WinDial;
    public MinigamesData minigamesData;

    private void Start()
    {
        dial = FindFirstObjectByType<p_dialHandler>();
    }

    public void OnMiniGameStart()
    {
        targetPosition = Random.Range(0, dial.maxPosition + 1);
        //Debug.Log(targetPosition);
    }

    public void UpdateDial()
    {
        Debug.Log("Actualiza la perilla");
        targetPosition = minigamesData.dialValue;
        if (dial.currentPosition == targetPosition)
        {
            correct = true;
            WinDial.Raise();
            Debug.Log("YUPPERS dial");
        }
        else
        {
            correct = false;
            Debug.Log("NOPE dial");
        }
    }
}
