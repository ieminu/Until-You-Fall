using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    MainManager mainManager;

    ScoreManager scoreManager;

    private void Start()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        if (transform.position.y < mainManager.DestroyingPositionY)
        {
            Destroy(gameObject);

            if (!mainManager.IsGameOver)
                scoreManager.AddScore();
        }
    }
}
