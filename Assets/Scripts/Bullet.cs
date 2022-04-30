using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    MainManager mainManager;

    ScoreManager scoreManager;

    GameObject parent;

    private void Awake()
    {
        parent = transform.parent.gameObject;
    }

    private void Start()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player Supporter")
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                
                if (!mainManager.IsGameOver)
                    scoreManager.AddScore();
            }

            gameObject.SetActive(false);
            transform.parent = parent.transform;
            transform.localPosition = Vector3.zero;
        }
    }
}
