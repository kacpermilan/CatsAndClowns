using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySequence : MonoBehaviour
{
    private GridManager _gridManager;

    private int _turn;
    
    [SerializeField]
    private GridCell[] _spawnPoints;
        
    [SerializeField] 
    private GameObject[] _enemyList;

    [SerializeField] 
    private GameObject _spawnPointMarkerPrefab;


    private void Start()
    {
        GameMaster.Instance.OnCurrentStateChange += OnCurrentStateChange;
        _gridManager = FindObjectOfType<GridManager>();
        
        ShuffleSpawnPoints();
        PrepareNewWave();
    }

    private void OnDestroy()
    {
        if (GameMaster.Instance != null)
        {
            GameMaster.Instance.OnCurrentStateChange -= OnCurrentStateChange;
        }
    }

    private void OnCurrentStateChange(object sender, GameMaster.OnCurrentStateChangeEventArgs e)
    {
        if (e.CurrentGameState == GameMaster.GameState.EnemySequence)
        {
            _turn++;
            ShuffleSpawnPoints();
            MoveExistingUnits();
            SpawnEnemyFromWave();
            PrepareNewWave();
            GameMaster.Instance.SetCurrentState(GameMaster.GameState.PlayerTurn);
        }
    }

    private void ShuffleSpawnPoints()
    {
        List<GridCell> spawnsWithEntities = new();
        List<GridCell> spawnsWithoutEntities = new();

        // Separate spawn points based on whether they contain an entity
        foreach (GridCell point in _spawnPoints)
        {
            if (point.GetEntityInCell() != null)
            {
                spawnsWithEntities.Add(point);
            }
            else
            {
                spawnsWithoutEntities.Add(point);
            }
        }

        // Shuffle the spawn points without entities
        for (int i = 0; i < spawnsWithoutEntities.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, spawnsWithoutEntities.Count);
            (spawnsWithoutEntities[i], spawnsWithoutEntities[randomIndex]) = (spawnsWithoutEntities[randomIndex], spawnsWithoutEntities[i]);
        }

        // Combine the two lists, with unoccupied spawn points first
        spawnsWithoutEntities.AddRange(spawnsWithEntities);
        _spawnPoints = spawnsWithoutEntities.ToArray();
    }

    private void MoveExistingUnits()
    {
        foreach (GridCell cell in _gridManager.GetAllCells())
        {
            if (cell.GetEntityInCell() == null)
            {
                continue;
            }

            AEnemyEntity enemy = cell.GetEntityInCell()?.GetComponent<AEnemyEntity>();
            if (enemy != null)
            {
                StartCoroutine(MoveEnemy(enemy, cell));
            }
        }
    }

    private IEnumerator MoveEnemy(AEnemyEntity enemy, GridCell startCell)
    {
        GridCell currentCell = startCell;

        for (int i = 0; i < enemy.movementSpeed; i++)
        {
            Vector2 leftPosition = GetLeftNeighbourPosition(currentCell.transform.position);
            GridCell targetCell = FindClosestCell(leftPosition);

            if (targetCell == null || targetCell.GetEntityInCell() != null)
            {
                break; // Stop moving if next cell is occupied or doesn't exist
            }

            enemy.StandingHere = false;
            yield return StartCoroutine(MoveToCell(enemy.gameObject, targetCell.transform.position, 1f));
            currentCell.PlaceEntityInCell(null);
            targetCell.PlaceEntityInCell(enemy.transform);
            currentCell = targetCell; // Update current cell for next iteration
            enemy.StandingHere = true;

            CheckAndDamageNeighboringPlayer(targetCell, enemy.attackStrength);
        }
    }


    private IEnumerator MoveToCell(GameObject enemy, Vector3 targetPosition, float duration)
    {
        float elapsed = 0;
        Vector3 startPosition = enemy.transform.position;

        while (elapsed < duration)
        {
            enemy.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        enemy.transform.position = targetPosition;
    }

    private void CheckAndDamageNeighboringPlayer(GridCell cell, int attackStrength)
    {
        Vector2 rightPosition = GetLeftNeighbourPosition(cell.transform.position);
        GridCell leftCell = FindClosestCell(rightPosition);

        if (leftCell == null)
        {
            return;
        }

        if (leftCell.GetEntityInCell() == null)
        {
            return;
        }

        APlayerEntity player = leftCell.GetEntityInCell()?.GetComponent<APlayerEntity>();
        if (player != null)
        {
            player.TakeDamage(attackStrength);
        }
    }

    private void SpawnEnemyFromWave()
    {
        foreach (GridCell spawnPoint in _spawnPoints)
        {
            if (spawnPoint.GetEntityInCell() == null)
            {
                continue;
            }

            Vector2 leftNeighbourPosition = GetLeftNeighbourPosition(spawnPoint.transform.position);
            GridCell targetCell = FindClosestCell(leftNeighbourPosition);

            if (targetCell != null && targetCell.GetEntityInCell() == null)
            {
                GameObject enemyPrefab = _enemyList[UnityEngine.Random.Range(0, _enemyList.Length)];
                GameObject enemy = Instantiate(enemyPrefab, targetCell.transform.position, Quaternion.identity);
                targetCell.PlaceEntityInCell(enemy.transform);
            }

            Destroy(spawnPoint.GetEntityInCell().gameObject);
        }
    }


    private void PrepareNewWave()
    {
        int numberOfSpawns = DetermineNumberOfSpawns();

        for (int i = 0; i < numberOfSpawns; i++)
        {
            GameObject warning = Instantiate(_spawnPointMarkerPrefab, _spawnPoints[i].transform.position, Quaternion.identity);
            _spawnPoints[i].PlaceEntityInCell(warning.transform);
        }
    }

    private Vector2 GetLeftNeighbourPosition(Vector2 cellPosition)
    {
        float meanCellDistance = 1.5f;
        return new Vector2(cellPosition.x - meanCellDistance, cellPosition.y);
    }


    private GridCell FindClosestCell(Vector2 targetPosition)
    {
        GridCell closestCell = null;
        float minDistance = float.MaxValue;

        foreach (GridCell cell in _gridManager.GetAllCells())
        {
            float distance = Vector2.Distance(cell.transform.position, targetPosition);
            if (!(distance < minDistance))
            {
                continue;
            }

            minDistance = distance;
            closestCell = cell;
        }

        return closestCell;
    }

        private int DetermineNumberOfSpawns()
        {
            return _turn switch
            {
                0 => 1,
                < 3 => UnityEngine.Random.Range(2, 4),
                < 10 => UnityEngine.Random.Range(2, 5),
                _ => UnityEngine.Random.Range(3, 5)
            };
        }
    }
