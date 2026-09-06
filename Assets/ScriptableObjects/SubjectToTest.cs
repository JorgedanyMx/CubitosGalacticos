using UnityEngine;

[CreateAssetMenu(fileName = "SubjectToTest", menuName = "Game/SubjectToTest")]
public class SubjectToTest : ScriptableObject
{
    public string subjectID;
    public string subjectHead;
    public string subjectBody;
    public void randomizeID()
    {
        int i = Random.Range(0, 2); // Genera 0 o 1
        subjectID = "0" + i;
    }
    public void randomizeHead()
    {
        subjectHead = $"HEAD_{subjectID}";
    }

    public void randomizeTorso()
    {
        subjectBody = $"TORSO_{subjectID}";
    }
}
