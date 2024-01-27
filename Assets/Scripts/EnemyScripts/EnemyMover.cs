using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [Header("Grid Cells check")]
    [SerializeField] private Transform _cellCheckOriginPoint;
    [SerializeField] private float _cellCheckRayLength;
    [SerializeField] private LayerMask _whatIsTraversable;

    [Header("Attacking")]
    [SerializeField] private float _damagePoints;

    // getter and setter methods for hasAttack created, so that TurnManager can set _hasAttact to false if state is changed to 
    // action state AND so that it can start PLAYERCHOICES state if every spawned enemy has attacked
    private bool _hasAttacked;

    private void Update()
    { 
        CheckIfCanMove();
    }

    private void CheckIfCanMove()
    {
       RaycastHit2D hitCollider = Physics2D.Raycast(_cellCheckOriginPoint.position, -Vector2.right, _cellCheckRayLength, _whatIsTraversable);
        if (hitCollider.collider.TryGetComponent(out GridCell gridCell))
        {
           bool IsPlayerOnGridCell = gridCell.GetPlayerEntityPlaced();
            if (IsPlayerOnGridCell)
            {
                if (!_hasAttacked)
                {
                     gridCell.GetPlayerEntityPlaced().GetComponent<Health>().TakeDamage(_damagePoints);
                    _hasAttacked = true;
                }
            }
            else
            {
                transform.position += new Vector3(-_moveSpeed * Time.deltaTime, 0, 0);
            }
        }
        else
        {
            //placeholder to stop null reference exception
            transform.position = Vector3.zero;
        }
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
        Gizmos.DrawLine(_cellCheckOriginPoint.position, new Vector2(_cellCheckOriginPoint.position.x + _cellCheckRayLength, _cellCheckOriginPoint.position.y));
    }
}
