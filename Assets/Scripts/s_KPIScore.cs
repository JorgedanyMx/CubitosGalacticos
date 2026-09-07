using UnityEngine;
using UnityEngine.UI;

public class s_KPIScore : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image scoreFill;

    [Header("Porcentajes")]
    [Range(0f, 100f)]
    [SerializeField] private float initialPercentage = 50f;

    [SerializeField] private float correctIncrease = 10f;
    [SerializeField] private float incorrectDecrease = 10f;

    [Header("Animación")]
    [SerializeField] private float fillSpeed = 1f;

    [Header("Carita de resultado")]
    [SerializeField] private Image faceImage;
    [SerializeField] private Sprite happyFace;
    [SerializeField] private Sprite sadFace;

    private float currentPercentage;
    private float targetFill;

    private void Start()
    {
        ResetScore();
    }

    private void Update()
    {
        scoreFill.fillAmount = Mathf.MoveTowards(
            scoreFill.fillAmount,
            targetFill,
            fillSpeed * Time.deltaTime
        );
    }

    // Llamada por el evento de respuesta correcta.
    public void AddCorrect()
    {
        currentPercentage += correctIncrease;
        UpdatePercentage();
    }

    // Llamada por el evento de respuesta incorrecta.
    public void AddIncorrect()
    {
        currentPercentage -= incorrectDecrease;
        UpdatePercentage();
    }

    private void UpdatePercentage()
    {
        currentPercentage = Mathf.Clamp(
            currentPercentage,
            0f,
            100f
        );

        targetFill = currentPercentage / 100f;

        UpdateFace();
    }

    public void ResetScore()
    {
        currentPercentage = initialPercentage;
        targetFill = currentPercentage / 100f;

        scoreFill.fillAmount = targetFill;

        UpdateFace();
    }

    private void UpdateFace()
    {
        if (currentPercentage >= 90f)
        {
            faceImage.sprite = happyFace;
        }
        else
        {
            faceImage.sprite = sadFace;
        }
    }
}