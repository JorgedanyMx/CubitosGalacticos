using UnityEngine;

public class s_BodyParts : MonoBehaviour
{
    [SerializeField] private GameObject[] bodyParts;
    [SerializeField] private Transform[] bodyPositions;

    private GameObject[] spawnedParts;

    public void SpawnBody()
    {
        DeletePreviousBody();

        int amountToSpawn = Mathf.Min(
            bodyParts.Length,
            bodyPositions.Length
        );

        spawnedParts = new GameObject[amountToSpawn];

        // Creamos un arreglo con los índices de las posiciones
        int[] availablePositions = new int[bodyPositions.Length];

        for (int i = 0; i < availablePositions.Length; i++)
        {
            availablePositions[i] = i;
        }

        // Mezclamos las posiciones
        for (int i = 0; i < availablePositions.Length; i++)
        {
            int randomIndex = Random.Range(i, availablePositions.Length);

            int temporary = availablePositions[i];
            availablePositions[i] = availablePositions[randomIndex];
            availablePositions[randomIndex] = temporary;
        }

        // Colocamos cada parte en una posición diferente
        for (int i = 0; i < amountToSpawn; i++)
        {
            Transform selectedPosition =
                bodyPositions[availablePositions[i]];

            spawnedParts[i] = Instantiate(
                bodyParts[i],
                selectedPosition.position,
                bodyParts[i].transform.rotation
            );
        }
    }

    private void DeletePreviousBody()
    {
        if (spawnedParts == null)
            return;

        foreach (GameObject bodyPart in spawnedParts)
        {
            if (bodyPart != null)
            {
                Destroy(bodyPart);
            }
        }
    }
}