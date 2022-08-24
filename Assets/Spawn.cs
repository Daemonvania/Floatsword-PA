using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Spawn
{
    public GameObject enemy;
    public Transform spawnPos;
    public float spawnTime;
  [HideInInspector] public bool isSpawned = false;
}

