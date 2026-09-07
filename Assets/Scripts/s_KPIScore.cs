using UnityEngine;
using UnityEngine.UI;

public class s_KPIScore : MonoBehaviour
{
    [Header("Datos")]
    [SerializeField] private GameData gameData;

    [Header("UI")]
    [SerializeField] private Image scoreFill;
    [SerializeField] private Image faceImage;

    [Header("Caritas")]
    [SerializeField] private Sprite happyFace;
    [SerializeField] private Sprite sadFace;

    [Header("Animación")]
    [SerializeField] private float fillSpeed = 1f;

    private float targetFill;

    private void Start()
    {
        scoreFill.fillAmount = 0f;
        targetFill = 0f;
        UpdateFace();
    }

    private void Update()
    {
        scoreFill.fillAmount = Mathf.MoveTowards(
            scoreFill.fillAmount,
            targetFill,
            fillSpeed * Time.deltaTime
        );
    }

    // Esta función debe llamarla el listener.
    public void UpdateKPI()
    {
        float kpi = gameData.GetKPI();
        
        Debug.Log("UpdateKPI llamado, valor recibido "+ kpi);
        targetFill = Mathf.Clamp01(kpi);
        UpdateFace();
    }

    private void UpdateFace()
    {
        if (targetFill >= 0.9f)
        {
            faceImage.sprite = happyFace;
        }
        else
        {
            faceImage.sprite = sadFace;
        }
    }
}