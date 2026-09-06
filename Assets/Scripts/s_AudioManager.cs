using UnityEngine;
using UnityEngine.Audio;

public class s_AudioManager : MonoBehaviour
{
    public GameData gameData;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] IntrosClips;
    [SerializeField] AudioClip[] IAVoicesClips;
    [SerializeField] AudioClip[] tutorialClips;

    public void playTutorial(int clipIndex)
    {
        audioSource.PlayOneShot(tutorialClips[clipIndex]);

    }
    public void playIntroClips(int clipIndex)
    {
        audioSource.PlayOneShot(IntrosClips[clipIndex]);
    }
    public void playIAVocesClips(int clipIndex)
    {
        audioSource.PlayOneShot(IAVoicesClips[clipIndex]);
    }

    public void playSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
