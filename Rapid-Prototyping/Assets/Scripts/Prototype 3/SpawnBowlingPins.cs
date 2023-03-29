using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBowlingPins : GameBehaviour
{
    public GameObject bowlingPin;
    public int spawnRange = 50;
    public int bowlingPinsSpawned;

    private void Update()
    {
        bowlingPinsSpawned = FindObjectsOfType<BowlingPin>().Length;
        if (bowlingPinsSpawned == 1)
            MakeBowlingPin(10);
    }

    void MakeBowlingPin(int bowlingPinsSpawned)
    {
        for (int i = 0; i < bowlingPinsSpawned; i++)
        {
            Instantiate(bowlingPin, RandomSpawnPos(), bowlingPin.transform.rotation);
        }
    }
    private Vector3 RandomSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
