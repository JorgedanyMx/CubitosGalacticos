using UnityEngine;
using System.Collections;

public class LuzVerdeTemporizada : MonoBehaviour
{
    private Light luzObjeto;

    void Start()
    {
        luzObjeto = GetComponent<Light>();

        if (luzObjeto == null)
        {
            Debug.LogError("No se encontró ningún componente Light en este GameObject.");
        }
    }

    public void luxes()
    {
        if (luzObjeto != null)
        {
          
            luzObjeto.color = Color.green;
            luzObjeto.enabled = true;

            StartCoroutine(ApagarDespuesDeTiempo());
        }
    }

    IEnumerator ApagarDespuesDeTiempo()
    {
        yield return new WaitForSeconds(5f);

        if (luzObjeto != null)
        {
            luzObjeto.enabled = false;
        }
    }
}
