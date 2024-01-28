using Cinemachine;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public static EnemyBoss Instance;

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHeatlh;

    private CinemachineImpulseSource _impulseSource;

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
