public class TankCat : APlayerEntity
{
    public TankCat()
        : base("Warrior Cat", "Tarcza szmato.", maxHealth: 3, attackStrength: 0, cost: 2)
    {
    }

    public override void DoAction()
    {
        // TODO: Melee attack
    }
}