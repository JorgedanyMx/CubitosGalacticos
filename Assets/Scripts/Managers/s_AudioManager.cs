using UnityEngine;
using UnityEngine.Audio;

public class s_AudioManager : MonoBehaviour
{
    public AudiosLeves audioSO;

    public GameData gameData;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        gameData.TotalSubjects(audioSO.IntrosClips.Length-1);
    }
    public void playTutorial(int clipIndex)
    {

        if (clipIndex > audioSO.tutorialClips.Length)
            Debug.Log("Auido fuera de rango");
        else
        {
            audioSource.pitch = 1f;
            audioSource.PlayOneShot(audioSO.tutorialClips[clipIndex]);
        }
    }
    public void IntroSujeto()
    {
        playIntroClips(gameData.currentPlayerID);
    }
    public void FinSujectoCorrecto()
    {
        playIAVocesClips(gameData.currentPlayerID);
    }
    public void playIntroClips(int clipIndex)
    {
        if (clipIndex > audioSO.IntrosClips.Length)
        {
            Debug.LogError("Audio fuera de rango");
        }
        else
        {
            audioSource.pitch = 1f;
            audioSource.PlayOneShot(audioSO.IntrosClips[clipIndex]);
        }
    }
    public void playIAVocesClips(int clipIndex)
    {
        if (clipIndex > audioSO.IAVoicesClips.Length)
        {
            Debug.LogError("Audio fuera de rango");
        }
        else
        {
            audioSource.pitch = 1f;
            audioSource.PlayOneShot(audioSO.IAVoicesClips[clipIndex]);
        }
    }
    public void BadEnding()
    {
        audioSource.pitch = 1f;
        audioSource.PlayOneShot(audioSO.tutorialClips[1]);
    }
    public void GoodEnding()
    {
        audioSource.pitch = 1f;
        audioSource.PlayOneShot(audioSO.tutorialClips[2]);
    }
    public void playSound(AudioClip audioClip)
    {
        audioSource.pitch = 1f;
        audioSource.PlayOneShot(audioClip);
    }
    public AudioClip GetAudioTutorial(int idx)
    {
        return audioSO.tutorialClips[idx];
    }
    public AudioClip GetAudioIntro(int idx)
    {
        return audioSO.IntrosClips[idx];
    }
    public AudioClip GetAudioIA(int idx)
    {
        return audioSO.IAVoicesClips[idx];
    }
    public void PlayScream()
    {
        float tmppitch = Random.Range(0f, .2f);
        audioSource.pitch = 1f+tmppitch;
        int randomScream = Random.Range(0,audioSO.GritosClips.Length);
        audioSource.PlayOneShot(audioSO.GritosClips[randomScream]);
    }
}
