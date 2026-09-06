using UnityEngine;

public class s_minijuegoManager : MonoBehaviour
{
    public GameEvent WinMinigameEvent;
    public GameEvent LostMinigameEvent;
    public GameEvent IniciaPruebaEvent;
    public GameEvent FinPruebaEvent;
    public minigameStates MgStates;

    private bool winSimon = false;
    private bool winPerilla = false;
    private bool winSliders = false;
    private bool winID = false;
    private bool winBody = false;

    private bool winMinigames = false;
    private bool winSubject = false;
    
    public void StartMiniGame()                                     //Se baja mirror
    {
        ResetScript();
        IniciaPruebaEvent.Raise();                                   //A modificaaaaaaaaaaaar con delay
    }
    public void IniciaPrueba()
    {
        //pass
        MgStates = minigameStates.InicioJuego;
    }
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
    public void RightID()
    {
        winID = true;
    }
    public void RightBody()
    {
        winBody = true;
    }
    public void MinilevelFinished()
    {
        winMinigames = winSliders && winSimon && winPerilla;
        winSubject = winID && winBody;
        if (winMinigames)
        {
            WinMinigameEvent.Raise();
        }
        else
        {
            LostMinigameEvent.Raise();
        }
        MgStates = minigameStates.FinJuego;
        FinPruebaEvent.Raise();
        ResetScript();
    }
    private void ResetScript()
    {
        MgStates = minigameStates.Presentacion;
        winSimon = false;
        winPerilla = false;
        winSliders = false;
        winMinigames = false;
        winID = false;
        winBody = false;
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