using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    GameObject gameOverScreen;

    GameObject player;

    GameObject joystickImage;

    public float DestroyingPositionY { get; private set; } = -2;

    public bool IsGameOver { get; private set; } = false;


    [System.Obsolete]
    private void Start()
    {
        gameOverScreen = GameObject.Find("Canvas").transform.FindChild("Game Over Screen").gameObject;
        player = GameObject.Find("Player");
        joystickImage = GameObject.Find("Joystick Image");
    }

    void Update()
    {
        if (joystickImage.activeSelf)
        {
            if (Input.anyKey)
            {
                joystickImage.SetActive(false);
            }
        }

        if (player.transform.position.y < DestroyingPositionY)
        {
            player.SetActive(false);
            GameOver();
        }
    }

    void GameOver()
    {
        IsGameOver = true;
        gameOverScreen.SetActive(true);
    }
}
