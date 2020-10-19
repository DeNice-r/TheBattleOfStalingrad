using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject enemy;
    public Transform target;

    void Start()
    {
        InvokeRepeating("EnemySpawner", 0f, 5f);
        var ds = enemy.GetComponent<AIDestinationSetter>();
        ds.target = target;
    }

    void Update()
    {
        
    }

    void EnemySpawner()
    {
        var sp = spawnpoints[(int)Math.Round(Random.value* (spawnpoints.Length-1))];
        Instantiate(enemy, sp.transform);
    }
}
