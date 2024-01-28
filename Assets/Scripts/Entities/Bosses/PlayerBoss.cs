using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBoss : MonoBehaviour
{
    public static PlayerBoss Instance;

    private CinemachineImpulseSource _impulseSource;

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHeatlh;

    private void Awake()
    {
        Instance = this;
        _currentHeatlh = _maxHealth;
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void TakeDamage(float damage)
    {
        _currentHeatlh -= damage;
        _impulseSource.GenerateImpulse();

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
