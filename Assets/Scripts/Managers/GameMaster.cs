using System;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    [SerializeField]
    private GameState _gameState;

    public event EventHandler<OnCurrentStateChangeEventArgs> OnCurrentStateChange;

    public enum GameState
    {
        PlayerTurn,
        PlayerAttack,
        EnemySequence
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _gameState = GameState.PlayerTurn;
    }

    public GameState GetCurrentGamePhase()
    {
        return _gameState;
    }

    public void SetCurrentState(GameState gameState)
    {
        this._gameState = gameState;
        
        OnCurrentStateChange?.Invoke(this, new OnCurrentStateChangeEventArgs { CurrentGameState = _gameState });
    }

    public class OnCurrentStateChangeEventArgs : EventArgs { public GameState CurrentGameState; }
}
