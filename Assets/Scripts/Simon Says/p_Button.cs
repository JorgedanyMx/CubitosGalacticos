using UnityEngine;
using UnityEngine.Animations;

public class p_Button : MonoBehaviour, p_IButton
{
    public int number;
    public Animator buttonAnim;
    public AudioSource audioSource;
    int p_IButton.Clicked()
    {
        buttonAnim.SetTrigger("HitButton");
        audioSource.Play();
        return number;
    }
    private void OnEnable()
    {
        audioSource.pitch = .8f + Random.Range(0f, .4f);
    }
}
