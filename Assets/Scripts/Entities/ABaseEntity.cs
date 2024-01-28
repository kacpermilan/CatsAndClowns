using System.Collections;
using UnityEngine;

public abstract class ABaseEntity : MonoBehaviour
{
    protected Animator _animator;

    protected string _name;
    
    protected string _description;

    protected int _currentHealth;

    protected int _maxHealth;

    public int attackStrength { get; private set; }

    protected ABaseEntity(string name, string description, int maxHealth, int attackStrength)
    {
        _name = name;
        _description = description;
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
        this.attackStrength = attackStrength;
    }

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public virtual void TakeDamage(int incomingDamage)
    {
        _currentHealth -= incomingDamage;

        Debug.Log("current health: " + _currentHealth);
        if (_currentHealth <= 0)
        {
            // SoundManager.PlayDeathSound(this);
            _animator.SetTrigger("Die");
            Collider2D cd = GetComponent<Collider2D>();
            cd.enabled = false;
            StartCoroutine(WaitForDeathAnimation());
        }
        else
        {
            // SoundManager.PlayDamageSound(this);
            _animator.SetTrigger("GotHit");
        }
    }

    private IEnumerator WaitForDeathAnimation()
    {
        // Wait for the animation to play
        yield return new WaitForSeconds(1f); // Replace 1f with the actual length of your 'Die' animation

        // Then destroy the game object
        Destroy(gameObject);
    }

    public float GetHealthNormalized() => (float)_currentHealth / _maxHealth;
}