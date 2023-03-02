using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : GameBehaviour<SpawnManager>
{
    public int waveNumber = 0;
    public int score = 0;
    public TMP_Text waveText;

    [Header("Enemy Spawn")]
    public GameObject enemyPrefab;
    public int enemiesSpawned;

    [Header("Powerup Spawn")]
    public GameObject powerupPrefab;

    private float spawnRange = 9;

    public GameObject winScreen;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void Update()
    {
        waveText.text = "Wave Number " + waveNumber;

        enemiesSpawned = FindObjectsOfType<Enemy>().Length;
        if (enemiesSpawned == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerups();

            AddScore(score);
            score++;
        }
        
        if (waveNumber == 10)
        {
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }
    }

    public void AddScore(int _score)
    {
        _score = score * _GM.scoreBonus;
        _UI.TweenScore(_score);
    }


    void SpawnEnemyWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefab, RandomSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerups()
    {
        Instantiate(powerupPrefab, RandomSpawnPos(), powerupPrefab.transform.rotation);
    }

    private Vector3 RandomSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
