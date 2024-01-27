using UnityEngine;

public abstract class ABaseEntity : MonoBehaviour
{
    private Animator _animator;

    [SerializeField]
    protected string Name;
    [SerializeField]
    protected string Description;
    [SerializeField]
   protected int AttackStrength;
    [SerializeField]
    protected int CurrentHealth;
    [SerializeField]
    protected int MaxHealth;

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