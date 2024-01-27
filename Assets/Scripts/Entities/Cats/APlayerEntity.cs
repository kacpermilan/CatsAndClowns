public abstract class APlayerEntity : ABaseEntity
{
    protected APlayerEntity(string name, string description, int maxHealth, int attackStrength, int cost)
        : base(name, description, maxHealth, attackStrength)
    {
        Cost = cost;
    }

    public int Cost { get; }

    public abstract void DoAction();
}
