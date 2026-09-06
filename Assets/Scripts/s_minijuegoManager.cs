using UnityEngine;

public class s_minijuegoManager : MonoBehaviour
{
    public GameEvent WinMinigameEvent;
    public GameEvent LostMinigameEvent;

    private bool winSimon = false;
    private bool winPerilla = false;
    private bool winSliders = false;
    private bool winMinigames = false;

    public void RightSimon()
    {
        winSimon = true;
    }
    public void RightPerilla()
    {
        winPerilla = true;
    }
    public void RightSliders()
    {
        winSliders = true;
    }
    public void MinilevelFinished()
    {
        winMinigames = winSliders && winSimon && winPerilla;
        if (winMinigames)
        {
            WinMinigameEvent.Raise();
        }
        else
        {
            LostMinigameEvent.Raise();
        }
        ResetScript();
    }
    private void ResetScript()
    {
        winSimon = false;
        winPerilla = false;
        winSliders = false;
        winMinigames = false;
    }
}
public enum minigameStates
{
    None,
    Presentacion,
    InicioJuego,
    FinJuego,
    Results,
}