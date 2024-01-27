using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance;

    public event EventHandler<OnResourcesChangedEventArgs> OnResourcesChanged;
    public class OnResourcesChangedEventArgs : EventArgs { public float currentResources; }

    public event EventHandler<OnPointsChangedEventArgs> OnPointsChanged;
    public class OnPointsChangedEventArgs : EventArgs { public int pointsLeftInCurrentTurn; }

    [SerializeField] private float _currentResurces;
    [SerializeField] private float _startingResources;

    [SerializeField] private int _pointsLeftInCurrentTurn;
    [SerializeField] private int _startingPointsInTurn;

    private void Awake()
    {
        Instance = this;
        _currentResurces = _startingResources;
    }

    private void Start()
    {
        //Domyślnie to będzie wywolywane gdy (enmum?) state na game/ turn managerze bedzie na state = PlayerDecisionTurn, czy cos.
        ResetPointsLeftInCurrentTurn();
    }

    public float GetCurrentResources()
    {
        return _currentResurces;
    }

    public void IncreaseResources(float amount)
    {
        _currentResurces += amount;
        OnResourcesChanged?.Invoke(this, new OnResourcesChangedEventArgs { currentResources = _currentResurces});
    }

    public void DecreaseResources(float amount)
    {
        _currentResurces -= amount;
        Debug.Log("Resources left: " + _currentResurces);
        OnResourcesChanged?.Invoke(this, new OnResourcesChangedEventArgs {currentResources = _currentResurces });
    }

    public int GetPointsLeftInCurrentTurn()
    {
        return _pointsLeftInCurrentTurn;
    }

    public void DecreasePointsLeftInCurrentTurn()
    {
        _pointsLeftInCurrentTurn -= 1;
        OnPointsChanged?.Invoke(this, new OnPointsChangedEventArgs {pointsLeftInCurrentTurn = _pointsLeftInCurrentTurn });
    }

    public void ResetPointsLeftInCurrentTurn()
    {
        // to be called by game (turns) manager once player starts his turn
        _pointsLeftInCurrentTurn = _startingPointsInTurn;
        OnPointsChanged?.Invoke(this, new OnPointsChangedEventArgs { pointsLeftInCurrentTurn = _pointsLeftInCurrentTurn });
    }
}
