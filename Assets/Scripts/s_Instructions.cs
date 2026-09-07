using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class s_Instructions : MonoBehaviour
{
    [Header("Datos")]
    [SerializeField] private MinigamesData minigamesData;

    [Header("Simon Says - V1 a V4")]
    [SerializeField] private Image[] colorImages;

    [Header("Sprites de colores")]
    [SerializeField] private Sprite greenSprite;
    [SerializeField] private Sprite blueSprite;
    [SerializeField] private Sprite purpleSprite;
    [SerializeField] private Sprite yellowSprite;

    [Header("Dial")]
    [SerializeField] private RectTransform dial;

    [Tooltip("Una rotación para cada valor del 1 al 10")]
    [SerializeField] private float[] dialRotations = new float[10];

    [Header("Slider")]
    [SerializeField] private RectTransform slider;

    [SerializeField] private Vector2 leftPosition;
    [SerializeField] private Vector2 centerPosition;
    [SerializeField] private Vector2 rightPosition;

    [Header("Tiempo de instrucciones")]
    [SerializeField] private GameObject[] instructionsObjects;
    [SerializeField] private float instructionsDuration = 5f;

    private Coroutine hideCoroutine;

    // Esta función debe conectarse al evento de iniciar la prueba.
    public void ShowInstructions()
    {
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        SetInstructionsActive(true);
        ConfigureInstructions();

        hideCoroutine = StartCoroutine(HideInstructions());
    }

    public void ConfigureInstructions()
    {
        ConfigureSimonSays();
        ConfigureDial();
        ConfigureSlider();
    }

    private void SetInstructionsActive(bool active)
    {
        foreach (GameObject instructionObject in instructionsObjects)
        {
            if (instructionObject != null)
            {
                instructionObject.SetActive(active);
            }
        }
    }

    private void ConfigureSimonSays()
    {
        if (string.IsNullOrWhiteSpace(minigamesData.simonSays))
            return;

        string[] colors = minigamesData.simonSays.Split(',');

        for (int i = 0; i < colorImages.Length; i++)
        {
            if (i < colors.Length)
            {
                colorImages[i].gameObject.SetActive(true);
                colorImages[i].sprite = GetColorSprite(colors[i]);
            }
            else
            {
                colorImages[i].gameObject.SetActive(false);
            }
        }
    }

    private Sprite GetColorSprite(string color)
    {
        string normalizedColor = color.Trim().ToLower();

        switch (normalizedColor)
        {
            case "verde":
                return greenSprite;

            case "azul":
                return blueSprite;

            case "morado":
                return purpleSprite;

            case "amarillo":
                return yellowSprite;

            default:
                Debug.LogWarning("No existe un sprite para el color: " + color);
                return null;
        }
    }

    private void ConfigureDial()
    {
        int dialValue = minigamesData.dialValue;

        if (dialValue < 1 || dialValue > 10)
        {
            Debug.LogWarning("dialValue debe estar entre 1 y 10.");
            return;
        }

        if (dialRotations.Length < 10)
        {
            Debug.LogWarning("Debes configurar 10 rotaciones para el dial.");
            return;
        }

        float zRotation = dialRotations[dialValue - 1];

        dial.localRotation = Quaternion.Euler(0f, 0f, zRotation);
    }

    private void ConfigureSlider()
    {
        switch (minigamesData.sliderValue)
        {
            case 1:
                slider.anchoredPosition = leftPosition;
                break;

            case 2:
                slider.anchoredPosition = centerPosition;
                break;

            case 3:
                slider.anchoredPosition = rightPosition;
                break;

            default:
                Debug.LogWarning("sliderValue debe estar entre 1 y 3.");
                break;
        }
    }

    private IEnumerator HideInstructions()
    {
        yield return new WaitForSeconds(instructionsDuration);

        SetInstructionsActive(false);
        hideCoroutine = null;
    }
}