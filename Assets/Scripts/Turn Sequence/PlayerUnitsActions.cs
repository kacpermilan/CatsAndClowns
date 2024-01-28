using System.Collections;
using UnityEngine;

public class PlayerUnitActions : MonoBehaviour
{
    private GridManager gridManager;

    private void Start()
    {
        GameMaster.Instance.OnCurrentStateChange += OnCurrentStateChange;
        gridManager = FindObjectOfType<GridManager>();
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
        if (e.CurrentGameState == GameMaster.GameState.PlayerAttack)
        {
            StartCoroutine(PerformActionsAndChangeState());
        }
    }

    private IEnumerator PerformActionsAndChangeState()
    {
        PerformActionsOnPlayerUnits();

        yield return new WaitForSeconds(1.5f);
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("ProjectileTag").Length == 0);

        GameMaster.Instance.SetCurrentState(GameMaster.GameState.EnemySequence);
    }

    private void PerformActionsOnPlayerUnits()
    {
        foreach (GridCell cell in gridManager.GetAllCells())
        {
            Transform entity = cell.GetEntityInCell();
            if (entity == null)
            {
                continue;
            }

            entity.TryGetComponent(out APlayerEntity playerEntity);

            if (playerEntity != null)
            {
                playerEntity.DoAction();
            }
        }
    }
}