using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class p_MinigameManager : MonoBehaviour
{
    [SerializeField] private MinigamesData Data;
    [SerializeField] private p_SimonSaysManager simonSays;
    [SerializeField] private p_SliderManager slider;
    [SerializeField] private p_DialManager dial;
    
    public void GameStart()
    {
        simonSays.GameStart();
        slider.OnMiniGameStart();
        dial.OnMiniGameStart();
        Data.simonSays = simonSays.stream;
        Data.sliderValue = slider.targetPosition;
        Data.dialValue = dial.targetPosition;
    }
    
}
