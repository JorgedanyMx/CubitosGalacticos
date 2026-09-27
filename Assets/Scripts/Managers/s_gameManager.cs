using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class s_gameManager : MonoBehaviour
{
    public GameData gameData;
    public s_AudioManager audioManager;
    public GameEvent StartGameEvent;
    public GameEvent StartMinigame;
    public GameEvent CinematicaFinal;
    public GameEvent BadEndingFinalEvent;
    public GameEvent ResetSceneEvent;

    void Start()
    {
        gameData.ResetData();
        StartGameEvent.Raise();
    }
    public void StartTutorial()
    {
        gameData.gameStates = GameStates.Tutorial;
        if (gameData.gameStates != GameStates.Tutorial)
            return;
        audioManager.playTutorial(0);
        StartCoroutine(FinTutorial(audioManager.GetAudioTutorial(0)));
    }
    public void FinMinijuegos()
    {
        Debug.Log("Se acabo el juego");
        if (gameData.GetKPI() > .9f)
        {
            StartCoroutine(EsperarAudioFin(5f, CinematicaFinal));

        }
        else
        {
            Debug.Log("Repetir nivel");
            StartCoroutine(EsperarAudioFin(5f, BadEndingFinalEvent));
        }
    }
    public void SujetoAprovado()
    {
        gameData.currentScore++;
    }
    IEnumerator FinTutorial(AudioClip clip)
    {
        // Espera la duración exacta del clip actual
        yield return new WaitForSeconds(clip.length);
        // El audio terminó, ejecuta tu código aquí
        Debug.Log("El tutorial ha terminado de reproducirse.");
        StartMinigame.Raise();
    }
    IEnumerator EsperarAudioFin(float timedelay, GameEvent gameEvent)
    {

        // Espera la duración exacta del clip actual
        yield return new WaitForSeconds(timedelay);
        gameEvent.Raise();
        Debug.Log("Se reprodujo" + gameEvent.name);
    }
    public void DelayBadEnding()
    {
        StartCoroutine(EsperarAudioFin(17,ResetSceneEvent));
    }
    public void BadEndingResetTutorial()
    {
        SceneManager.LoadScene(0);
    }
}
