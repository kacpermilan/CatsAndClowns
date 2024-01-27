public class LaserCat : APlayerEntity
{
    public LaserCat()
        : base("Rainbow Cat", "Ima Firing My Lazer.", maxHealth: 1, attackStrength: 2, cost: 3)
    {
        
    }

    public override void DoAction()
    {
        throw new System.NotImplementedException();
    }
}