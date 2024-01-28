using UnityEngine;

public abstract class AEnemyEntity : ABaseEntity
{
    private bool _standingHere;

    public bool StandingHere
    {
        get => _standingHere;
        set
        {
            _standingHere = value;
            //_animator.SetBool("IsStationary", _standingHere);
        }
    }

    public int movementSpeed { get; private set; }
    public int attackRange { get; private set; }

    protected AEnemyEntity(string name, string description, int health, int attackStrength, int movementSpeed, int attackRange)
        : base(name, description, health, attackStrength)
    {
        this.movementSpeed = movementSpeed;
        this.attackRange = attackRange;
    }

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        StandingHere = true;
    }
}