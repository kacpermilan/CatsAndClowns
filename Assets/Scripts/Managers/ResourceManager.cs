using System;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    private float _currentResources;
    private const int STARTING_RESOURCES = 1;

    public event EventHandler<OnResourcesChangedEventArgs> OnResourcesChanged;

    private void Awake()
    {
        Instance = this;
        _currentResources = STARTING_RESOURCES;
    }

    public float GetCurrentResources() => _currentResources;

    public void IncreaseResources(float amount)
    {
        _currentResources += amount;
        OnResourcesChanged?.Invoke(this, new OnResourcesChangedEventArgs { CurrentResources = _currentResources});
    }

    public void DecreaseResources(float amount)
    {
        _currentResources -= amount;
        Debug.Log("Resources left: " + _currentResources);
        OnResourcesChanged?.Invoke(this, new OnResourcesChangedEventArgs {CurrentResources = _currentResources });
    }

    public class OnResourcesChangedEventArgs : EventArgs { public float CurrentResources; }
}
