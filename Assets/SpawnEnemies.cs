using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{ 
    public Spawn[] spawns;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        float seconds =  timer % 60;
        print(seconds);
        foreach (Spawn spawn in spawns)
        {
            if (!spawn.isSpawned && spawn.spawnTime <= seconds)
            {
                Instantiate(spawn.enemy, spawn.spawnPos);
                spawn.isSpawned = true;
            }
        }
    }
}