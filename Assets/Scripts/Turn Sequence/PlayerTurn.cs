using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTurn : MonoBehaviour
{
    public static PlayerTurn Instance;

    //[SerializeField] 
    //private LayerMask _whatIsPlaceable;

    //This is the cell mouse is currently hovering over
    [SerializeField] 
    private GridCell _currentGridCell;

    //To implement -> this is Entity. It changes based on the card player chooses
    [SerializeField] 
    private Transform _currentlySelectedEntity;

    [SerializeField] private bool _isOverUIElement;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameMaster.Instance.OnCurrentStateChange += OnCurrentStateChange;
        InputManager.Instance.OnMouseClick += InputManager_OnMouseClick;
        InputManager.Instance.OnGetRemoveObject += InstanceOnOnGetRemoveObject;
    }

    private void Update()
    {
       
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            _isOverUIElement = false;
             SearchForClickableObjects();
        }
        else
        {
            _isOverUIElement = true;
            SearchForCards();
        }
              
    }

    private void OnCurrentStateChange(object sender, GameMaster.OnCurrentStateChangeEventArgs e)
    {
        if (e.CurrentGameState is GameMaster.GameState.PlayerTurn)
        {
            
        }
    }

    private void SearchForCards()
    {
        PointerEventData pointerEventData = new(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new();
        EventSystem.current.RaycastAll(pointerEventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.TryGetComponent(out Card card))
            {
                _currentlySelectedEntity = card.GetEntityInThisCard();
                // Debug.Log("Card " + card.gameObject.name);
                break;
            }
        }
    }


    private void InputManager_OnMouseClick(object sender, System.EventArgs e)
    {
        if (GameMaster.Instance.GetCurrentGamePhase() != GameMaster.GameState.PlayerTurn)
        {
            //It means, currently it's not the phase when player can place entities on grid
            return;
        }


        if (_isOverUIElement) return;
        // Check if player has chosen any card
        if (_currentlySelectedEntity == null)
        {
            Debug.Log("No Entity Selected To Place");
            return;
        }

        // Check if player hovers over any grid cell
        if (_currentGridCell == null)
        {
            Debug.Log("You cannot place anything here");
            return;
        }

        APlayerEntity entity = _currentlySelectedEntity.GetComponent<APlayerEntity>();

        //If the cell mouse hovers over is placeable
        if (!_currentGridCell.IsPlaceable())
        {
            Debug.Log("You cannot place anything here");
            return;
        }

        // To implement -> here you'll also check if player have enough points to place selected entity
        if (ResourceManager.Instance.GetCurrentResources() >= entity.Cost)
        {
            ResourceManager.Instance.DecreaseResources(entity.Cost);

            //Place chosen entity on the cell you currently hover over
            _currentGridCell.OnMouseClick();
        }
        else
        {
            Debug.Log("You have no money to place this entity");
        }
    }

    private void InstanceOnOnGetRemoveObject(object sender, EventArgs e)
    {
        if (GameMaster.Instance.GetCurrentGamePhase() != GameMaster.GameState.PlayerTurn)
        {
            //It means, currently it's not the phase when player can place entities on grid
            return;
        }

        // Check if player hovers over any grid cell
        if (_currentGridCell == null)
        {
            Debug.Log("You cannot place anything here");
            return;
        }

        Transform entityTransform = _currentGridCell.GetEntityInCell();
        if (entityTransform == null)
        {
            return;
        }

        // Get the APlayerEntity component from the GameObject
        APlayerEntity playerEntity = entityTransform.GetComponent<APlayerEntity>();

        if (playerEntity != null)
        {
            Destroy(playerEntity.gameObject);
        }
    }

    private void SearchForClickableObjects()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out GridCell gridCell))
            {
                _currentGridCell = gridCell;
            }
            else
            {
                _currentGridCell =      //gridCell.OnMouseClick();
                null;
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
