using UnityEngine;
using UnityEngine.Audio;

public class s_AudioManager : MonoBehaviour
{
    public AudiosLeves audioSO;

    public GameData gameData;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource audioSource;

    public void playTutorial(int clipIndex)
    {

        if (clipIndex > audioSO.tutorialClips.Length)
            Debug.Log("Auido fuera de rango");
        else
            audioSource.PlayOneShot(audioSO.tutorialClips[clipIndex]);

    }
    public void playIntroClips(int clipIndex)
    {
        if (clipIndex > audioSO.tutorialClips.Length)
            Debug.Log("Auido fuera de rango");
        else
            audioSource.PlayOneShot(audioSO.IntrosClips[clipIndex]);
    }
    public void playIAVocesClips(int clipIndex)
    {
        if (clipIndex > audioSO.tutorialClips.Length)
            Debug.Log("Auido fuera de rango");
        else
            audioSource.PlayOneShot(audioSO.IAVoicesClips[clipIndex]);
    }

    public void playSound(AudioClip audioClip)
    {
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
}
