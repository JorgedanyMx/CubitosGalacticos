using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class s_gameManager : MonoBehaviour
{
    public GameData gameData;
    public s_AudioManager audioManager;
    public GameEvent StartGameEvent;
    public GameEvent StartMinigame;
    public GameEvent CinematicaFinal;

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
        if(gameData.gameStates == GameStates.cinematica)
        {
            Debug.Log("Se acabo el juego");
            if (gameData.GetKPI() >.9f)
            {
                CinematicaFinal.Raise();
            }
            else
            {
                Debug.Log("Repetir nivel");
            }
        }
    }
    IEnumerator FinTutorial(AudioClip clip)
    {
        // Espera la duración exacta del clip actual
        yield return new WaitForSeconds(clip.length);
        // El audio terminó, ejecuta tu código aquí
        Debug.Log("El tutorial ha terminado de reproducirse.");
        StartMinigame.Raise();
    }
    IEnumerator EsperarAudioFin(AudioClip clip)
    {

        // Espera la duración exacta del clip actual
        yield return new WaitForSeconds(clip.length);

        // El audio terminó, ejecuta tu código aquí
        Debug.Log("El audio ha terminado de reproducirse.");

    }
}
