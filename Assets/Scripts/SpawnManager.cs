using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    MainManager mainManager;

    readonly int[] Operators = { -1, +1 };

    GameObject enemyPrefab;
    GameObject powerupPrefab;

    [SerializeField] float spawnRateForEnemy;
    [SerializeField] float spawnRateForPowerup;

    [SerializeField] float spawnRange;

    float timePassedForEnemy;
    float timePassedForPowerup;

    int enemiesToSpawn = 1;

    bool hasAnEnemySpawned = false;

    bool isAbleToSpawn;

    private void Start()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        enemyPrefab = Resources.Load("Enemy") as GameObject;
        powerupPrefab = Resources.Load("Powerup") as GameObject;
    }

    private void Update()
    {
        if (!mainManager.IsGameOver)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                timePassedForEnemy += Time.deltaTime;

                if (timePassedForEnemy >= spawnRateForEnemy)
                {
                    SpawnEnemyWave();
                    timePassedForEnemy = 0;
                }
            }
        }

        if (!hasAnEnemySpawned)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            {
                hasAnEnemySpawned = true;
                isAbleToSpawn = true;
            }
        }

        if (hasAnEnemySpawned && !mainManager.IsGameOver)
        {
            if (isAbleToSpawn)
            {
                SpawnPowerup();
                isAbleToSpawn = false;
            }

            timePassedForPowerup += Time.deltaTime;

            if (timePassedForPowerup >= spawnRateForPowerup)
            {
                isAbleToSpawn = true;
                timePassedForPowerup = 0;
            }
        }
    }

    void SpawnEnemyWave()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            float randomPositionX = Random.Range(-spawnRange, spawnRange + 1);
            Vector3 randomPosition = new Vector3(randomPositionX, 0, Random.Range(0f, spawnRange - Mathf.Abs(randomPositionX)) * Operators[Random.Range(0, 2)]);
            Instantiate(enemyPrefab, randomPosition, enemyPrefab.transform.rotation);
        }

        enemiesToSpawn++;
    }

    void SpawnPowerup()
    {
        float randomPositionX = Random.Range(-spawnRange - 1, spawnRange);
        Vector3 randomPosition = new Vector3(randomPositionX, 0, Random.Range(0f, spawnRange - Mathf.Abs(randomPositionX)) * Operators[Random.Range(0, 2)]);
        Instantiate(powerupPrefab, randomPosition, powerupPrefab.transform.rotation);
    }
}
