using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyWave
{
    //Once we have more than 1 type of enemy, we can increase array, so that different types of enemies / combinations get spawned each wave
    [SerializeField] private Transform[] _enemies;

    [SerializeField] private int _numbersOfEnemiesToSpawn;

    [SerializeField] private float _timeBetweenEnemiesSpawning;


    // I created two options, as I'm not sure what we will eventually decide on
    public Transform GetSelectedEnemy(int enemyIndex)
    {
        return _enemies[enemyIndex];
    }

    public Transform GetRandomEnemy()
    {
        return _enemies[UnityEngine.Random.Range(0, _enemies.Length)];
    }

    public int GetNumberOfEnemiesToSpawn()
    {
        return _numbersOfEnemiesToSpawn;
    }

    public float GetTimeBetweenEnemiesSpawning()
    {
        return _timeBetweenEnemiesSpawning;
    }
    
}
