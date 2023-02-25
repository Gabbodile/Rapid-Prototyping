using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : GameBehaviour<SpawnManager>
{
    public int waveNumber = 1;
    public TMP_Text waveText;
    public int score = 0;

    [Header("Enemy Spawn")]
    public GameObject enemyPrefab;
    public int enemiesSpawned;

    [Header("Powerup Spawn")]
    public GameObject powerupPrefab;

    private float spawnRange = 9;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerups();
    }

    public void Update()
    {
        enemiesSpawned = FindObjectsOfType<Enemy>().Length;
        if (enemiesSpawned == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerups();
        }
        waveText.text = "Wave Number " + waveNumber;
    }

    public void AddScore(int _score)
    {
        score = score += waveNumber;
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
