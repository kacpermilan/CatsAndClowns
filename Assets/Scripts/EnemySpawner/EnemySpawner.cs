using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawningState { SPAWNING, WAITING, AWAITINGTOSPAWN}

    [SerializeField] private EnemyWave[] _enemyWaves;

    [SerializeField] private int _currentWaveIndex;

    [SerializeField] private SpawningState _spawnState;

    [SerializeField] private Transform[] _spawnPoints;

    // So that we can iterate through all the spawned enemies and only change SpawningState to AWAITINGSPAWN and
    // GameState to PLAYERCHOICES when all of the currently spawn enemies HasAttacked (ememyMover) and 
    // and set it back to false when ACTIONSTATE starts again.
    
    //We also need a way to remove spawned enemies from the list, when ther're destroyed

    [SerializeField] private List<Transform> _spawnedEnemies = new();
 
    private void Update()
    {

        if (GameMaster.Instance.GetCurrentGamePhase() == GameMaster.GameState.EnemySequence)
        {
            if (_spawnState == SpawningState.WAITING)
            {
                for (int i = 0; i < _spawnedEnemies.Count; i++)
                {
                    if (!_spawnedEnemies[i].GetComponent<EnemySequence>().HasAttacked())
                    {
                        return;
                    }

                    //needs to do the bellow only once there are no EnemyMovers which !HasAttacked
                    //Not sure how to implement it. My brain is dead at this point xD
                    _spawnState = SpawningState.AWAITINGTOSPAWN;
                    GameMaster.Instance.SetCurrentState(GameMaster.GameState.PlayerTurn);
                }
            }

            if (_spawnState != SpawningState.SPAWNING)
            {
                StartCoroutine(SpawningRoutine());
            }
        }
    }

    private IEnumerator SpawningRoutine()
    {
        _spawnState = SpawningState.SPAWNING;

        for (int i = 0; i < _enemyWaves[_currentWaveIndex].GetNumberOfEnemiesToSpawn(); i++)
        {
            SpawnEnemyFromWave();
            yield return new WaitForSeconds(0);
        }

        //test
        _spawnState = SpawningState.WAITING;
        _currentWaveIndex++;
        //GameMaster.Instance.SetCurrentState(GameMaster.GameState.PLAYERCHOICES);
    }

    private void SpawnEnemyFromWave()
    {
        // I choose to get a random enemy from a selection of enemies in that particular wave
        //but if you want to change that, every wave have a method to return an enemy with selected index
        // Enemies spawn at random position from 4 possible spawn points. To make it different, and let player know which lines
        //the enemies will spawn at first, it will require way more work. So, here's the basics

        //Spawn points will be hidden under graphics element with higher layer order.
        //It's done such way, so that we can actually get the lines of first enemies, once they're spawn, but not moving,
        //If we have time to implement it
        Transform enemyInstance = Instantiate(_enemyWaves[_currentWaveIndex].GetRandomEnemy(), _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
        _spawnedEnemies.Add(enemyInstance);

    }
}
