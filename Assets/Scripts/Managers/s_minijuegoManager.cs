using UnityEngine;
using System.Collections;


public class s_minijuegoManager : MonoBehaviour
{
    public GameEvent WinMinigameEvent;
    public GameEvent LostMinigameEvent;
    public GameEvent IniciaPruebaEvent;
    public GameEvent FinPruebaEvent;
    public GameEvent StartMinigameEvent;
    public GameData gameData;
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
        gameData.gameStates =GameStates.Minijuego;
        ResetScript();
        gameData.AddSubjectCount();
        gameData.playerScore += 1;
        StartCoroutine(DelayNextPrueba(10000));
    }
    public void IniciaPrueba()
    {
        //pass
        MgStates = minigameStates.InicioJuego;
    }
    public void FinPrueba()
    {
        MgStates = minigameStates.FinJuego;
        FinPruebaEvent.Raise();
        if (gameData.playerScore >= gameData.GetTotalSub())
        {
            gameData.gameStates = GameStates.cinematica;
        }
        StartCoroutine(DelayNextPrueba(10000));
    }

    IEnumerator DelayNextStage(int delaytime)
    {
        // Espera la duración exacta del clip actual
        yield return new WaitForSeconds(delaytime);
        IniciaPruebaEvent.Raise();
    }
    IEnumerator DelayNextPrueba(int delaytime)
    {
        // Espera la duración exacta del clip actual
        yield return new WaitForSeconds(delaytime);
        IniciaPruebaEvent.Raise();
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