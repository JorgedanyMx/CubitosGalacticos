using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData")]
public class GameData : ScriptableObject
{
    public int playerScore = 0; 
    public int currentScore = 0;
    public GameStates gameStates = GameStates.None;

    public void ResetData()
    {
        playerScore = 0;
        currentScore = 0;
    }
}
public enum GameStates
{
    None,
    Intro,
    Presentacion,
    Minijuego,
    AfterMinijuego,
    Results,
    End,
    cinematica
}