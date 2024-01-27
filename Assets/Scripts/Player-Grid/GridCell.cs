using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] 
    private bool _isEnemyCell;

    [SerializeField] private Transform _entityInCell;

    public void OnMouseClick()
    {
        if (IsPlaceable())
        {
            Transform playerEntityChosenToPlace = PlayerTurn.Instance.GetCurrentlySelectedEntity();
            Transform playerEntityInstance = Instantiate(playerEntityChosenToPlace, transform.position, Quaternion.identity);
            PlaceEntityInCell(playerEntityInstance);
            Debug.Log("PLACED");
        }
        else if (_entityInCell != null)
        {
            Debug.Log("You cannot place your entity on this cell. This cell is being occupied.");
        }
        else
        {
            Debug.Log("You cannot place your entity on this cell. This cell belong to the enemy.");
        }
    }

    public bool IsPlaceable() => !_isEnemyCell && _entityInCell == null;

    public Transform GetEntityInCell() => _entityInCell;

    public void PlaceEntityInCell(Transform entity) => _entityInCell = entity;
}
