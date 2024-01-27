using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] private bool _isPlaceable;
    //So that rightHand side Cells are never placeable for player
    [SerializeField] private bool _isEnemyCell;

    [SerializeField] private Transform _playerEntityPlaced;
    

    private void Awake()
    {
        if (_isEnemyCell)
        {
            _isPlaceable = false;
        }
        else
        {
            _isPlaceable = true;
        }
    }
    public void OnMouseClick()
    {
        if (_isPlaceable)
        {
           Transform _playerEntityChosenToPlace = EntityPlacer.Instance.GetCurrentlySelectedEntity();
            Transform playerEntityInstance = Instantiate(_playerEntityChosenToPlace, transform.position, Quaternion.identity);
            _playerEntityPlaced = playerEntityInstance;
            Debug.Log("PLACED");
            _isPlaceable = false;
        }
        else
        {
            Debug.Log("You cannot place your entity on this cell");
        }
    }

    public bool IsPlaceable()
    {
        return _isPlaceable;
    }

    public Transform GetPlayerEntityPlaced()
    {
        return _playerEntityPlaced;
    }
}
