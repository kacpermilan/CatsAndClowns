using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    public static EndTurnButton Instance;

    // So that we can switch on and off this button visibility once we have entire states loop working
    [SerializeField] private GameObject _buttonObject;

    [SerializeField] private Button _endTurnBttn;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        TurnsManager.Instance.OnCurrentStateChange += TurnsManager_OnCurrentStateChange;
        _endTurnBttn.onClick.AddListener(() =>
        {
            TurnsManager.Instance.SetCurrentState(TurnsManager.State.ACTIONSTATE);
            _buttonObject.SetActive(false);
        });
    }

    private void TurnsManager_OnCurrentStateChange(object sender, TurnsManager.OnCurrentStateChangeEventArgs e)
    {
        if (e.currentState == TurnsManager.State.PLAYERCHOICES)
        {
            _buttonObject.SetActive(true);
            PointsManager.Instance.ResetPointsLeftInCurrentTurn();
        }
    }
}
