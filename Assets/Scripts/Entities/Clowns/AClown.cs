public abstract class AClown : ABaseEntity
{
    public int Speed { get; protected set; }
    public int AttackRange { get; protected set; }

    protected AClown(string name, string description, int health, int attackStrength, int speed, int attackRange)
        : base(name, description, health, attackStrength)
    {
        Speed = speed;
        AttackRange = attackRange;
    }
}