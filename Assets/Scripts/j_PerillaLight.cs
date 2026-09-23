using UnityEngine;

public class j_PerillaLight : MonoBehaviour
{
    [SerializeField] Material LGmaterial;
    public Color currentColor;
    public float intensity = 8f;
    void Start()
    {
        LGmaterial.SetColor("_EmissionColor", currentColor * 0f);
    }
    public void TurnOn()
    {
        LGmaterial.SetColor("_EmissionColor", currentColor* intensity);
    }
    public void TurnOff()
    {
        LGmaterial.SetColor("_EmissionColor", currentColor * 0f);
    }
}
