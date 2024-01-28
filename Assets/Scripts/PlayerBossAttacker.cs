using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBossAttacker : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _whatIsPlayerBoss;
    [SerializeField] private float _damagePoints;

    private void Update()
    {
        LookForPlayer();
    }

    private void LookForPlayer()
    {
       RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, _distance, _whatIsPlayerBoss);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<PlayerBoss>().TakeDamage(_damagePoints);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + _distance, transform.position.y));
    }
}
