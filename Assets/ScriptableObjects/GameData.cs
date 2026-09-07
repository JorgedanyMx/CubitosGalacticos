using System.Collections.Generic;
using Unity.Multiplayer.PlayMode;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData")]
public class GameData : ScriptableObject
{
    public int playerScore = 0; 
    public int currentScore = 0;
    private int totalSubjects = 0;
    public int currentPlayerID = 0;
    public float minigametime = 10f;
    public GameStates gameStates = GameStates.None;


    private List<int> numerosDisponibles = new List<int>();
    public void AddSubjectCount()
    {
        totalSubjects++;
    }
    public float GetKPI()
    {
        if(totalSubjects==0)
            return 0;
        return currentScore/totalSubjects;
    }
    public void TotalSubjects(int subjects)
    {
        totalSubjects = subjects;
    }
    public int GetTotalSub()
    {
        return totalSubjects;
    }
    public void ResetData()
    {
        playerScore = 0;
        currentScore = 0;
        currentScore = 0;
        currentPlayerID = 0;
        minigametime = 10;
    }
    public void ObtenerNumeroSinRepetirHastaAgotar()
    {
        // Si la lista está vacía, la volvemos a llenar con la secuencia
        if (numerosDisponibles.Count == 0)
        {
            for (int i = 0; i < totalSubjects; i++)
            {
                numerosDisponibles.Add(i);
            }
        }

        // Elegimos un índice al azar de los números disponibles
        int indiceAleatorio = Random.Range(0, numerosDisponibles.Count);
        int numeroElegido = numerosDisponibles[indiceAleatorio];

        // Eliminamos el número usado para no volverlo a tomar en esta ronda
        numerosDisponibles.RemoveAt(indiceAleatorio);

        currentPlayerID = numeroElegido;
    }
}
public enum GameStates
{
    None,
    Tutorial,
    Presentacion,
    Minijuego,
    AfterMinijuego,
    Results,
    End,
    cinematica
}