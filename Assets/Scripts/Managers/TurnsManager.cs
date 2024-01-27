using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnsManager : MonoBehaviour
{
    public enum State
    {
        PLAYERCHOICES,
        ACTIONSTATE, 
    }

    public static TurnsManager Instance;

    public event EventHandler<OnCurrentStateChangeEventArgs> OnCurrentStateChange;
    public class OnCurrentStateChangeEventArgs : EventArgs { public State currentState; }

    public State _state = new State();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _state = State.PLAYERCHOICES;
    }

    public State GetCurrentGamePhase()
    {
        return _state;
    }

    public void SetCurrentState(State state)
    {
        _state = state;
        
        OnCurrentStateChange?.Invoke(this, new OnCurrentStateChangeEventArgs { currentState = _state });
    }
}
