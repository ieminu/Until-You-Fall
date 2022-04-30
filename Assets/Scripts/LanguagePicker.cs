using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanguagePicker : MonoBehaviour
{
    public enum Languages
    {
        English,
        Turkish
    }

    Button englishButton;
    Button turkishButton;

    public static string CurrentLanguage { get; private set; }

    [System.Obsolete]
    private void Start()
    {
        CurrentLanguage = PlayerPrefs.GetString("Saved Language", Languages.English.ToString());

        englishButton = GameObject.Find("Canvas").transform.FindChild("Settings Panel").transform.FindChild("Language").transform.FindChild("English Button").gameObject.GetComponent<Button>();
        turkishButton = GameObject.Find("Canvas").transform.FindChild("Settings Panel").transform.FindChild("Language").transform.FindChild("Turkish Button").gameObject.GetComponent<Button>();

        englishButton.onClick.AddListener(EnglishLanguageButton);
        turkishButton.onClick.AddListener(TurkishLanguageButton);
    }

    void EnglishLanguageButton()
    {
        CurrentLanguage = Languages.English.ToString();
        PlayerPrefs.SetString("Saved Language", CurrentLanguage);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    void TurkishLanguageButton()
    {
        CurrentLanguage = Languages.Turkish.ToString();
        PlayerPrefs.SetString("Saved Language", CurrentLanguage);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
