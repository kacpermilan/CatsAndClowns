using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private int _moveSpeed; // Assuming this is the number of tiles to move

    [Header("Grid Cells check")]
    [SerializeField] private Transform _cellCheckOriginPoint;
    [SerializeField] private float _cellCheckRayLength;
    [SerializeField] private LayerMask _whatIsTraversable;

    [Header("Attacking")]
    [SerializeField] private int _damagePoints;

    private bool _hasAttacked;

    [SerializeField]
    private float _tileWidth = 10.0f; // Adjust this based on your grid size

    private void Awake() => GameMaster.Instance.OnCurrentStateChange += OnCurrentStateChange;
    private void OnCurrentStateChange(object sender, GameMaster.OnCurrentStateChangeEventArgs e)
    {
        if (e.CurrentGameState == GameMaster.GameState.EnemySequence)
        {
            CheckIfCanMove();
        }
    }

    private void CheckIfCanMove()
    {
        RaycastHit2D hitCollider = Physics2D.Raycast(_cellCheckOriginPoint.position, -Vector2.right, _cellCheckRayLength, _whatIsTraversable);
        if (hitCollider.collider != null && hitCollider.collider.TryGetComponent(out GridCell gridCell))
        {
            bool isPlayerOnGridCell = gridCell.GetEntityInCell();
            if (isPlayerOnGridCell)
            {
                if (!_hasAttacked)
                {
                    gridCell.GetEntityInCell().GetComponent<ABaseEntity>().TakeDamage(_damagePoints);
                    _hasAttacked = true;
                }
            }
            else
            {
                MoveEnemy();
            }
        }
        else
        {
            //placeholder to stop null reference exception
            transform.position = Vector3.zero;
        }
    }

    private void MoveEnemy()
    {
        // Assuming each tile is directly to the left of the current position
        Vector3 nextPosition = transform.position + new Vector3(-_tileWidth, 0, 0);
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, _moveSpeed * Time.deltaTime);
    }

    public bool HasAttacked()
    {
        return _hasAttacked;
    }

    public void ResetHasAttacked()
    {
        _hasAttacked = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_cellCheckOriginPoint.position, new Vector2(_cellCheckOriginPoint.position.x - _cellCheckRayLength, _cellCheckOriginPoint.position.y));
    }
}
