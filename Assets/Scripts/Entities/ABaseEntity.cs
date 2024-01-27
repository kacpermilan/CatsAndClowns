using UnityEngine;

public abstract class ABaseEntity : MonoBehaviour
{
    private Animator _animator;

    [SerializeField]
    protected string _name;
    
    [SerializeField]
    protected string _description;
    
    [SerializeField]
    protected int _attackStrength;

    [SerializeField]
    protected int _currentHealth;
    
    [SerializeField]
    protected int _maxHealth;

    protected ABaseEntity(string name, string description, int maxHealth, int attackStrength)
    {
        _name = name;
        _description = description;
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
        _attackStrength = attackStrength;
    }

    private void Awake()
    {
        //_animator = GetComponent<Animator>();
    }

    public void TakeDamage(int incomingDamage)
    {
        // SoundManager.PlayDamageSound(this);
        //_animator.SetTrigger("Shoot");
        _currentHealth -= incomingDamage;

        Debug.Log("current health: " + _currentHealth);
        if (_currentHealth <= 0)
        {
            // SoundManager.PlayDeathSound(this);
            _animator.SetTrigger("Die");
        }
    }

    public float GetHealthNormalized() => (float)_currentHealth / _maxHealth;
}