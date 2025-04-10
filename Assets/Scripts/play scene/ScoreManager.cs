using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("TextMeshPro Components")]
    public TextMeshProUGUI blueScoreText;
    public TextMeshProUGUI orangeScoreText;

    private int blueScore = 0;
    private int orangeScore = 0;

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddPointToBlue()
    {
        blueScore++;
        UpdateScoreUI();
    }

    public void AddPointToOrange()
    {
        orangeScore++;
        UpdateScoreUI();
    }

    public void ResetScores()
    {
        blueScore = 0;
        orangeScore = 0;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (blueScoreText != null)
            blueScoreText.text = blueScore.ToString();

        if (orangeScoreText != null)
            orangeScoreText.text = orangeScore.ToString();
    }
}
