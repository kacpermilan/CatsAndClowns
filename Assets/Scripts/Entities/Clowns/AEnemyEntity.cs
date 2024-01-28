public abstract class AEnemyEntity : ABaseEntity
{
    public int movementSpeed { get; private set; }
    public int attackRange { get; private set; }

    protected AEnemyEntity(string name, string description, int health, int attackStrength, int movementSpeed, int attackRange)
        : base(name, description, health, attackStrength)
    {
        this.movementSpeed = movementSpeed;
        this.attackRange = attackRange;
    }
}