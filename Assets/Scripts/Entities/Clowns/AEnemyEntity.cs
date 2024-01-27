using UnityEngine;

public abstract class AEnemyEntity : ABaseEntity
{
    private int _movementSpeed;
    private int _attackRange;

    protected AEnemyEntity(string name, string description, int health, int attackStrength, int movementSpeed, int attackRange)
        : base(name, description, health, attackStrength)
    {
        _movementSpeed = movementSpeed;
        _attackRange = attackRange;
    }
}