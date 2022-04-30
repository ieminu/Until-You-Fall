using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLanguageSetter : MonoBehaviour
{
    ScoreManager scoreManager;

    Text gameOverText;
    Text respawnButtonText;
    Text menuButtonText;

    TextMeshProUGUI scoreTextString;
    TextMeshProUGUI highScoreTextString;

    [System.Obsolete]
    private void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();

        GameObject gameOverScreen = GameObject.Find("Canvas").transform.FindChild("Game Over Screen").gameObject;
    
        gameOverText = gameOverScreen.transform.FindChild("Game Over Text").GetComponent<Text>();
        respawnButtonText = gameOverScreen.transform.FindChild("Respawn Button").transform.FindChild("Text").GetComponent<Text>();
        menuButtonText = gameOverScreen.transform.FindChild("Menu Button").transform.FindChild("Text").GetComponent<Text>();

        scoreTextString = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        highScoreTextString = GameObject.Find("High Score Text").GetComponent<TextMeshProUGUI>();

        if (LanguagePicker.CurrentLanguage == LanguagePicker.Languages.English.ToString())
        {
            SetLanguageAsEnglish();
        }

        else if (LanguagePicker.CurrentLanguage == LanguagePicker.Languages.Turkish.ToString())
        {
            SetLanguageAsTurkish();
        }

        scoreManager.scoreTextString = scoreTextString.text;
        scoreManager.highScoreTextString = highScoreTextString.text;
    }

    void SetLanguageAsEnglish()
    {
        gameOverText.text = "You Died!";
        respawnButtonText.text = "Respawn";
        respawnButtonText.fontSize = 21;
        menuButtonText.text = "Menu";
        scoreTextString.text = "Score: ";
        highScoreTextString.text = "High Score: ";
    }

    void SetLanguageAsTurkish()
    {
        gameOverText.text = "Öldün!";
        respawnButtonText.text = "Yeniden Oyna";
        respawnButtonText.fontSize = 15;
        menuButtonText.text = "Menü";
        scoreTextString.text = "Skor: ";
        highScoreTextString.text = "Rekor: ";
    }
}
