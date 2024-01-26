using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPlacer : MonoBehaviour
{

    [SerializeField] private LayerMask _whatIsPlaceable;

    [SerializeField] private GridCell _currentGridCell;

    private void Start()
    {
        InputManager.Instance.OnMouseClick += InputManager_OnMouseClick;
    }

    private void InputManager_OnMouseClick(object sender, System.EventArgs e)
    {
        _currentGridCell.OnMouseClick();
    }

    private void Update()
    {
        SearchForClickableGridCell();
    }

    private void SearchForClickableGridCell()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, _whatIsPlaceable);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out GridCell gridCell))
            {
                _currentGridCell = gridCell;
                //gridCell.OnMouseClick();
            }
            else
            {
                _currentGridCell = null;
            }
        }
        else
        {
            _currentGridCell = null;
        }
      
        
        
    }
}
