using UnityEngine;

public abstract class APlayerEntity : ABaseEntity
{
    [SerializeField]
    public int Cost;

    protected APlayerEntity(string name, string description, int maxHealth, int attackStrength, int cost)
        : base(name, description, maxHealth, attackStrength)
    {
        Cost = cost;
    }
}
