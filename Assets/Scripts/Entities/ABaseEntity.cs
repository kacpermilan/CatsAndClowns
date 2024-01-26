using UnityEngine;

public abstract class ABaseEntity : MonoBehaviour
{
    private Animator _animator;

    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int AttackStrength { get; protected set; }
    public int CurrentHealth { get; private set; }
    public int MaxHealth { get; protected set; }

    protected ABaseEntity(string name, string description, int maxHealth, int attackStrength)
    {
        Name = name;
        Description = description;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        AttackStrength = attackStrength;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        // SoundManager.PlayDamageSound(this);
        _animator.SetTrigger("Shoot");
        CurrentHealth =- amount;

        if (CurrentHealth <= 0)
        {
            // SoundManager.PlayDeathSound(this);
            _animator.SetTrigger("Die");
        }
    }
}