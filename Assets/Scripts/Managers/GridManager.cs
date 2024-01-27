using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    [SerializeField] 
    private GridCell[] gridCells;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        gridCells = FindObjectsOfType<GridCell>();
    }

    public GridCell[] GetAllCells()
    {
        return gridCells;
    }
}