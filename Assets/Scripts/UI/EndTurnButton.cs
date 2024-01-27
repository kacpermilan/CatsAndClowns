using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    public static EndTurnButton Instance;

    [SerializeField] 
    private GameObject _buttonObject;

    [SerializeField] 
    private Button _endTurnBttn;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameMaster.Instance.OnCurrentStateChange += TurnsManager_OnCurrentStateChange;

        _endTurnBttn.onClick.AddListener(() =>
        {
            GameMaster.Instance.SetCurrentState(GameMaster.GameState.PlayerAttack);
            _buttonObject.SetActive(false);
        });
    }

    private void TurnsManager_OnCurrentStateChange(object sender, GameMaster.OnCurrentStateChangeEventArgs e)
    {
        if (e.CurrentGameState != GameMaster.GameState.PlayerTurn)
        {
            return;
        }

        _buttonObject.SetActive(true);
    }
}
