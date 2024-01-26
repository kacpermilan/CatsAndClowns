public abstract class ABaseEntity
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Health { get; protected set; }
    public int AttackStrength { get; protected set; }

    protected ABaseEntity(string name, string description, int health, int attackStrength)
    {
        Name = name;
        Description = description;
        Health = health;
        AttackStrength = attackStrength;
    }
}