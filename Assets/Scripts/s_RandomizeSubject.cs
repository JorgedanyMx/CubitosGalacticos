using UnityEngine;

public class s_RandomizeSubject : MonoBehaviour
{

    [SerializeField] GameObject subjectActive;



    [SerializeField] private GameObject[] headPrefabs;
    [SerializeField] private GameObject[] torsoPrefabs;

    [SerializeField] private MeshFilter activeHead;
    [SerializeField] private MeshFilter activeTorso;

    public void SpawnSubject()
    {
        int randomHead = Random.Range(0, headPrefabs.Length);
        int randomTorso = Random.Range(0, torsoPrefabs.Length);

        GameObject selectedHead = headPrefabs[randomHead];
        GameObject selectedTorso = torsoPrefabs[randomTorso];

        MeshFilter headMesh = selectedHead.GetComponent<MeshFilter>();
        MeshRenderer headRenderer = selectedHead.GetComponent<MeshRenderer>();

        MeshFilter torsoMesh = selectedTorso.GetComponent<MeshFilter>();
        MeshRenderer torsoRenderer = selectedTorso.GetComponent<MeshRenderer>();

        activeHead.sharedMesh = headMesh.sharedMesh;
        activeHead.GetComponent<MeshRenderer>().sharedMaterials =
            headRenderer.sharedMaterials;

        activeTorso.sharedMesh = torsoMesh.sharedMesh;
        activeTorso.GetComponent<MeshRenderer>().sharedMaterials =
            torsoRenderer.sharedMaterials;
    }
}
