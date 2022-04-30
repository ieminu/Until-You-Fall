using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    GameObject settingsPanel;

    [System.Obsolete]
    private void Start()
    {
        GameObject.Find("Play Button").GetComponent<Button>().onClick.AddListener(Play);
        GameObject.Find("Settings Button").GetComponent<Button>().onClick.AddListener(Settings);
        GameObject.Find("Exit Button").GetComponent<Button>().onClick.AddListener(Exit);

        settingsPanel = GameObject.Find("Canvas").transform.FindChild("Settings Panel").gameObject;
    }

    void Play()
    {
        DontDestroyOnLoad(GameObject.Find("Language Picker"));
        SceneManager.LoadSceneAsync("Game");
    }

    void Settings()
    {
        settingsPanel.SetActive(true);
    }

    void Exit()
    {
        Application.Quit();
    }
}
