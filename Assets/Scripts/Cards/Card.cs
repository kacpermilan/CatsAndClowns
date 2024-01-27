using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private Transform _entityInThisCard;

    private bool _isUnlocked;

    public Transform GetEntityInThisCard()
    {
        return _entityInThisCard;

    }

    public bool IsUnlocked()
    {
        return _isUnlocked;
    }
}
