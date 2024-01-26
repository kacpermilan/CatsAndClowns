public abstract class ACat : ABaseEntity
{
    public int Cost { get; protected set; }

    protected ACat(string name, string description, int health, int attackStrength, int cost)
        : base(name, description, health, attackStrength)
    {
        Cost = cost;
    }
}

