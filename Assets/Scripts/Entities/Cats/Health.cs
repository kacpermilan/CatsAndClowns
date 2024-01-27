using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log("current health: " + _currentHealth);

        if (_currentHealth <= 0)
        {
            //die
            Debug.Log("current health " + _currentHealth);
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public float GetHealthNormalized()
    {
        return _currentHealth / _maxHealth;
    }
}
