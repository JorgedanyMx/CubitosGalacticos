using UnityEngine;

public class p_SliderManager : MonoBehaviour
{
    private p_moveSlider slider;
    private Vector3 targetPosition;
    bool correct;
    private void Start()
    {
        slider = FindFirstObjectByType<p_moveSlider>();
        
    }
    public void OnMiniGameEnd()
    {
        if (Vector3.Distance(targetPosition, slider.finalPosition) <= 0.5f)
        {
            correct = true;
            Debug.Log("YUPPERS Slider");
        }
        else
        {
            correct = false;
            Debug.Log("NOPE slider");
        }
    }
    public void OnMiniGameStart()
    {
        float r = Random.Range(0f, 1f);
        targetPosition = Vector3.Lerp(slider.min.position, slider.max.position, r);
        Debug.Log(targetPosition);
    }
}
