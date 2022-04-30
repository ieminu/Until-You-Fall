using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    MainManager mainManager;

    TextMeshProUGUI scoreText;
    TextMeshProUGUI highScoreText;

    int score;
    int highScore;

    public string scoreTextString;
    public string highScoreTextString;

    private void Start()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.Find("High Score Text").GetComponent<TextMeshProUGUI>();

        highScore = PlayerPrefs.GetInt("High Score", 0);
    }

    private void Update()
    {
        if (score > highScore)
        {
            highScore = score;
        }

        scoreText.text = scoreTextString + score;
        highScoreText.text = highScoreTextString + highScore;

        if (mainManager.IsGameOver && score > PlayerPrefs.GetInt("High Score", 0))
        {
            PlayerPrefs.SetInt("High Score", score);
        }
    }

    public void AddScore()
    {
        score += 10;
    }
}
