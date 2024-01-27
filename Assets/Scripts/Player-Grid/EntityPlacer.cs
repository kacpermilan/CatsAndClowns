using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPlacer : MonoBehaviour
{
    public static EntityPlacer Instance;

    [SerializeField] private LayerMask _whatIsPlaceable;

    //This is the cell mouse is currently hovering over
    [SerializeField] private GridCell _currentGridCell;

    //To implement -> this is Entity. It changes based on the card player chooses
    [SerializeField] private Transform _currentlySelectedEntity;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InputManager.Instance.OnMouseClick += InputManager_OnMouseClick;
    }

    private void InputManager_OnMouseClick(object sender, System.EventArgs e)
    {
        if (TurnsManager.Instance.GetCurrentGamePhase() != TurnsManager.State.PLAYERCHOICES)
        {
            //It means, currently it's not the phase when player can place entities on grid
            return;
        }

        // if player choose any card
        if (_currentlySelectedEntity != null)
        {
            //If player hovers over any grid cell
            if (_currentGridCell != null)
            {
               APlayerEntity entity = _currentlySelectedEntity.GetComponent<APlayerEntity>();
                
                //If the cell mouse hovers over is placeable
                if (_currentGridCell.IsPlaceable())
                {
                    // To implement -> here you'll also check if player have enough points to place selected entity
                    if (PointsManager.Instance.GetCurrentResources() >= entity.Cost)
                    {
                        if (PointsManager.Instance.GetPointsLeftInCurrentTurn() >= 1)
                        {
                            PointsManager.Instance.DecreasePointsLeftInCurrentTurn();
                            PointsManager.Instance.DecreaseResources(entity.Cost);
                            //Place chosen entity on the cell you currently hover over
                            _currentGridCell.OnMouseClick();
                        }
                        else
                        {
                            Debug.Log("You have no points left to use");
                        }

                    }
                    else
                    {
                        Debug.Log("You have no money to place this entity");
                    }
                }
                else
                {
                    Debug.Log("You cannot place anything here");
                }

               

            }
            else
            {
                Debug.Log("You cannot place anything here");
            }
        }
        else
        {
            Debug.Log("No Entity Selected To Place");
            //Display info about no entity selected to place
        }
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

    public Transform GetCurrentlySelectedEntity()
    {
        return _currentlySelectedEntity;
    }
}
