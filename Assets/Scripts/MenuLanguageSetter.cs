using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLanguageSetter : MonoBehaviour
{
    Text playButtonText;
    Text settingsButtonText;
    Text exitButtonText;
    Text languageText;

    [System.Obsolete]
    private void Start()
    {
        playButtonText = GameObject.Find("Play Button").transform.FindChild("Text").GetComponent<Text>();
        settingsButtonText = GameObject.Find("Settings Button").transform.FindChild("Text").GetComponent<Text>();
        exitButtonText = GameObject.Find("Exit Button").transform.FindChild("Text").GetComponent<Text>();
        languageText = GameObject.Find("Canvas").transform.FindChild("Settings Panel").transform.FindChild("Language").GetComponent<Text>();

        if (LanguagePicker.CurrentLanguage == LanguagePicker.Languages.English.ToString())
        {
            SetLanguageAsEnglish();
        }

        else if (LanguagePicker.CurrentLanguage == LanguagePicker.Languages.Turkish.ToString())
        {
            SetLanguageAsTurkish();
        }
    }

    void SetLanguageAsEnglish()
    {
        playButtonText.text = "Play";
        settingsButtonText.text = "Settings";
        exitButtonText.text = "Exit";
        languageText.text = "Language";
    }

    void SetLanguageAsTurkish()
    {
        playButtonText.text = "Oyna";
        settingsButtonText.text = "Ayarlar";
        exitButtonText.text = "Çýk";
        languageText.text = "Dil";
    }
}
