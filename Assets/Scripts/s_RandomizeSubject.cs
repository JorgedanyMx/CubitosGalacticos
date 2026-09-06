using UnityEngine;

public class s_RandomizeSubject : MonoBehaviour
{

    [Header("Subjet To Test")]
    [SerializeField] private SubjectToTest subjectData;
    [SerializeField] GameObject subjectActive;



    [SerializeField] private GameObject[] headPrefabs;
    [SerializeField] private GameObject[] torsoPrefabs;

    [SerializeField] private MeshFilter activeHead;
    [SerializeField] private MeshFilter activeTorso;

    

    public void SpawnSubject()
    {
        //int randomHead = Random.Range(0, headPrefabs.Length);
        //int randomTorso = Random.Range(0, torsoPrefabs.Length);
        subjectData.randomizeID();
        subjectData.randomizeHead();
        subjectData.randomizeTorso();
        
        GameObject selectedHead = null;
        GameObject selectedTorso = null;

        foreach(GameObject prefab in headPrefabs)
        {
            if(prefab.name == subjectData.subjectHead)
            {
                selectedHead = prefab;
                break;
            }
        }

        foreach (GameObject prefab in torsoPrefabs)
        {
            if(prefab.name == subjectData.subjectBody)
            {
                selectedTorso = prefab;
                break;
            }
        }

        if(selectedHead == null || selectedTorso == null)
        {
            Debug.LogError("No se obtuvieron los datos");
            return;
        }

        activeHead.sharedMesh =
            selectedHead.GetComponent<MeshFilter>().sharedMesh;

        activeHead.GetComponent<MeshRenderer>().sharedMaterials =
            selectedHead.GetComponent<MeshRenderer>().sharedMaterials;

        activeTorso.sharedMesh =
            selectedTorso.GetComponent<MeshFilter>().sharedMesh;

        activeTorso.GetComponent<MeshRenderer>().sharedMaterials =
            selectedTorso.GetComponent<MeshRenderer>().sharedMaterials;
    }
}
