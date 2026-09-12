using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class j_timerScript : MonoBehaviour
{
    [Header("Configuración")]
    public Image imagenFill;
    public GameData gameData;
    bool enPrueba=false;

    private void Update()
    {
        if (enPrueba)
        {
            if (imagenFill != null)
            {
                imagenFill.fillAmount = Mathf.Clamp01(gameData.minigameCountDown / gameData.minigametime);
            }
        }
        else
        {
            imagenFill.fillAmount = 0f;
        }
    }
    public void PruebaFinalizada()
    {
        enPrueba = false;
    }
    public void PruebaIniciada()
    {
        enPrueba = true;
    }
}
