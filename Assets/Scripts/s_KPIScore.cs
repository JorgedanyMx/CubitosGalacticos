using UnityEngine;
using UnityEngine.UI;

public class s_KPIScore : MonoBehaviour
{
    [Header("UI Bars")]
    [SerializeField] private Image correctBar;
    [SerializeField] private Image errorBar;

    [Header("Score Configuration")]
    [SerializeField] private int maximumScore = 10;
    [SerializeField] private float fillSpeed = 1f;

    private int correctScore;
    private int errorScore;

    private float correctTarget;
    private float errorTarget;

    private void Start()
    {
        ResetScores();
    }

    private void Update()
    {
        correctBar.fillAmount = Mathf.MoveTowards(
            correctBar.fillAmount,
            correctTarget,
            fillSpeed * Time.deltaTime
        );

        errorBar.fillAmount = Mathf.MoveTowards(
            errorBar.fillAmount,
            errorTarget,
            fillSpeed * Time.deltaTime
        );
    }

    public void AddCorrectPoint()
    {
        correctScore++;

        correctScore = Mathf.Clamp(
            correctScore,
            0,
            maximumScore
        );

        correctTarget = (float)correctScore / maximumScore;
    }

    public void AddErrorPoint()
    {
        errorScore++;

        errorScore = Mathf.Clamp(
            errorScore,
            0,
            maximumScore
        );

        errorTarget = (float)errorScore / maximumScore;
    }

    public void ResetScores()
    {
        correctScore = 0;
        errorScore = 0;

        correctTarget = 0f;
        errorTarget = 0f;

        correctBar.fillAmount = 0f;
        errorBar.fillAmount = 0f;
    }
}