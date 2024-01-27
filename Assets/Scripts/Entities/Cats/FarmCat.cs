public class FarmCat : APlayerEntity
{
    public FarmCat()
        : base("Bread Cat", "A simple loaf of bread.", maxHealth: 50, attackStrength: 10, cost: 3)
    {
        
    }

    public override void DoAction()
    {
        ResourceManager.Instance.IncreaseResources(1);
    }
}