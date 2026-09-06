using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class s_gameManager : MonoBehaviour
{
   public GameData gameData;
    void Start()
    {
        gameData.gameStates=GameStates.Intro;
    }
}
