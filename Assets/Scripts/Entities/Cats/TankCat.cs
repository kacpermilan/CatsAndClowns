public class TankCat : APlayerEntity
{
    public TankCat()
        : base("Warrior Cat", "Tarcza szmato.", maxHealth: 3, attackStrength: 1, cost: 1)
    {
        
    }

    public override void DoAction()
    {
        throw new System.NotImplementedException();
    }
}