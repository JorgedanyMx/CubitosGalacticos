using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SubjectToTest", menuName = "Game/SubjectToTest")]
public class SubjectToTest : ScriptableObject
{
    public string subjectID;
    public string subjectHead;
    public string subjectBody;

    private int previousHead = -1;
    private int previousTorso = -1;
    private HashSet<int> usedIDs = new HashSet<int>();
    public void randomizeID()
    {
        if (usedIDs.Count >= 999)
        {
            Debug.LogWarning("Ya se utilizaron todos los IDs disponibles.");
            return;
        }

        int newID;

        do
        {
            newID = Random.Range(1, 1000);
        }
        while (usedIDs.Contains(newID));

        usedIDs.Add(newID);

        subjectID = newID.ToString("D3");

        Debug.Log("Nuevo ID: " + subjectID);
    
    }
    public void randomizeHead()
    {
        int newHead;

        do
        {
            newHead = Random.Range(0, 3);
        }
        while (newHead == previousHead);

        previousHead = newHead;
        subjectHead = $"HEAD_{newHead:D3}";

        Debug.Log("Nueva cabeza: " + subjectHead);
    }

    public void randomizeTorso()
    {
        int newTorso;

        do
        {
            newTorso = Random.Range(0, 3);
        }
        while (newTorso == previousTorso);

        previousTorso = newTorso;
        subjectBody = $"TORSO_{newTorso:D3}";

        Debug.Log("Nuevo torso: " + subjectBody);
    }
}
