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
    public GameEvent FinishAllTestsEvents;
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
        gameData.playerScore += 1;
        gameData.UpdateNuevoSujetoID();
        gameData.minigameCountDown = gameData.minigametime;
        StartCoroutine(DelayNextPrueba(5f));

    }
    public void IniciaPrueba()
    {
        Debug.Log("Holaaa empiexza purbasjhdhasjdgsahjgdhjsadghjksa");
        MgStates = minigameStates.InicioJuego;
        StartCoroutine(ContadorRegresivo());
    }
    public void FinPrueba()
    {
        if (gameData.playerScore >= gameData.GetTotalSub())
        {
            gameData.gameStates = GameStates.cinematica;
            FinishAllTestsEvents.Raise();
            Debug.Log("Se acabooo ya tooooooo porque no acabaaa");
        }
        else 
        {
            StartCoroutine(DelayNextMinigame(5f));
        }
    }
    IEnumerator FinishMinigame(float delaytime)
    {
        // Espera la duración exacta del clip actual
        yield return new WaitForSeconds(delaytime);
        FinPruebaEvent.Raise();
        gameData.minigametime -= 1f;
        MgStates = minigameStates.FinJuego;
        Debug.Log("Finaliza Prueba");
    }
    IEnumerator DelayNextMinigame(float delaytime)
    {
        // Espera la duración exacta del clip actual
        yield return new WaitForSeconds(delaytime);
        StartMinigameEvent.Raise();
    }
    IEnumerator DelayNextPrueba(float delaytime)
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
        ResetScript();
    }
    public IEnumerator ContadorRegresivo()
    {
        Debug.Log("Empieza Prueba contador");
        float tmpTime = gameData.minigameCountDown;
        while (gameData.minigameCountDown > 0)
        {
            // Restamos el tiempo transcurrido en cada frame
            gameData.minigameCountDown -= Time.deltaTime;
            // Esperamos al siguiente fotograma
            yield return null;
        }
        // Mensaje final cuando la cuenta llega a cero
        FinPruebaEvent.Raise();
        gameData.minigametime -= 1f;
        MgStates = minigameStates.FinJuego;
        Debug.Log("Finaliza Prueba");
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