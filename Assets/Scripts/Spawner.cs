using Pathfinding;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float period;
    public GameObject[] spawnpoints;
    public GameObject enemy;
    public Transform target;

    void Start()
    {
        InvokeRepeating("EnemySpawner", 0f, period);
        var ds = enemy.GetComponent<AIDestinationSetter>();
        ds.target = target;
    }

    void EnemySpawner()
    {
        var sp = spawnpoints[(int)Math.Round(Random.value* (spawnpoints.Length-1))];
        Instantiate(enemy, sp.transform);
    }
}
