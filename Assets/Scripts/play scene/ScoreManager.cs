using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    
    [Header("Text Mesh Pro References")]
    [SerializeField] private TextMeshProUGUI orangeScoreText;
    [SerializeField] private TextMeshProUGUI blueScoreText;

    private int orangeScore = 0;
    private int blueScore = 0;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    // Public function to increment orange score
    public void AddOrangeScore(int points = 1)
    {
        orangeScore += points;
        UpdateScoreUI();
    }

    // Public function to increment blue score
    public void AddBlueScore(int points = 1)
    {
        blueScore += points;
        UpdateScoreUI();
    }

    // Public function to reset both scores
    public void ResetScores()
    {
        orangeScore = 0;
        blueScore = 0;
        UpdateScoreUI();
    }

    // Update the UI texts to reflect current scores
    private void UpdateScoreUI()
    {
        if (orangeScoreText != null)
            orangeScoreText.text = orangeScore.ToString();

        if (blueScoreText != null)
            blueScoreText.text = blueScore.ToString();
    }
}
