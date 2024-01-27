using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public static EnemyBoss Instance;

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHeatlh;

    private void Awake()
    {
        Instance = this;
        _currentHeatlh = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHeatlh -= damage;

        if (_currentHeatlh <= 0)
        {
            //SceneManager.LoadScene(3);
        }
    }

    public float GetHealthNormalized()
    {
        return _currentHeatlh / _maxHealth;
    }
}
