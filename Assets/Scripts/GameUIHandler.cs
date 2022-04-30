using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIHandler : MonoBehaviour
{
    Button respawnButton;
    Button menuButton;

    [System.Obsolete]
    private void Start()
    {
        GameObject gameOverScreen = GameObject.Find("Canvas").transform.FindChild("Game Over Screen").gameObject;

        respawnButton = gameOverScreen.transform.FindChild("Respawn Button").GetComponent<Button>();
        menuButton = gameOverScreen.transform.FindChild("Menu Button").GetComponent<Button>();

        respawnButton.onClick.AddListener(Respawn);
        menuButton.onClick.AddListener(Menu);
    }

    void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
