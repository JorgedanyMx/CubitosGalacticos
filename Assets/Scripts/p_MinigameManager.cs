using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class p_MinigameManager : MonoBehaviour
{
    [SerializeField] private GameEvent OnMiniGameBegin;
    [SerializeField] private GameEvent OnMiniGameEnd;
    [SerializeField] private p_SimonSaysManager simonSays;
    [SerializeField] private p_moveSlider slider;
    [SerializeField] private p_dialHandler dial;
    
    public void MiniGameBegin()
    {
        OnMiniGameBegin.Raise();
    }

    public void MiniGameEnd()
    {
        OnMiniGameEnd.Raise();
    }
    
}
