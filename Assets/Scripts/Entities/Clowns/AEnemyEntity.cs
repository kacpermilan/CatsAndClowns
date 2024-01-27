public abstract class AEnemyEntity : ABaseEntity
{
    public int MovementSpeed { get; protected set; }
    public int AttackRange { get; protected set; }

    protected AEnemyEntity(string name, string description, int health, int attackStrength, int movementSpeed, int attackRange)
        : base(name, description, health, attackStrength)
    {
        MovementSpeed = movementSpeed;
        AttackRange = attackRange;
    }
}