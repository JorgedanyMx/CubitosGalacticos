using TMPro;
using UnityEngine;

public class s_RandomizeSubject : MonoBehaviour
{

    [Header("Subjet To Test")]
    [SerializeField] private SubjectToTest subjectData;
    [SerializeField] GameObject subjectActive;

    [Header("ID")]
    [SerializeField] private TMP_Text subjectIDText;


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

        subjectIDText.text = subjectData.subjectID;
        
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

        MeshFilter selectedHeadMesh =
            selectedHead.GetComponent<MeshFilter>();

        Debug.Log(
            $"Dato: {subjectData.subjectHead} | " +
            $"Prefab: {selectedHead.name} | " +
            $"Mesh origen: {selectedHeadMesh.sharedMesh.name}"
        );

        activeHead.sharedMesh = selectedHeadMesh.sharedMesh;

        activeHead.GetComponent<MeshRenderer>().sharedMaterials =
            selectedHead.GetComponent<MeshRenderer>().sharedMaterials;

        Debug.Log(
            "Mesh colocado en activeHead: " +
            activeHead.sharedMesh.name
        );

        activeTorso.sharedMesh =
            selectedTorso.GetComponent<MeshFilter>().sharedMesh;

        activeTorso.GetComponent<MeshRenderer>().sharedMaterials =
            selectedTorso.GetComponent<MeshRenderer>().sharedMaterials;
    }
}
