public abstract class ACat : ABaseEntity
{
    public int Cost { get; protected set; }

    protected ACat(string name, string description, int maxHealth, int attackStrength, int cost)
        : base(name, description, maxHealth, attackStrength)
    {
        Cost = cost;
    }
}
