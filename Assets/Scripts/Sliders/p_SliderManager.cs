using UnityEngine;

public class p_SliderManager : MonoBehaviour
{
    private p_moveSlider slider;
    public int targetPosition;
    bool correct;

    private void Start()
    {
        slider = FindFirstObjectByType<p_moveSlider>();
    }

    public void OnMiniGameEnd()
    {
        if (slider.currentPosition == targetPosition)
        {
            correct = true;
            Debug.Log("YUPPERS");
        }
        else
        {
            correct = false;
            Debug.Log("NOPE");
        }
    }

    public void OnMiniGameStart()
    {
        // maxPosition is a const, inclusive range: 0, 1, or 2
        //targetPosition = Random.Range(0, p_moveSlider.maxPosition + 1);
        Debug.Log("Target position index: " + targetPosition);
    }
}
