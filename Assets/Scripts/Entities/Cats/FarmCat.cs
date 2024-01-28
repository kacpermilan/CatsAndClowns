public class FarmCat : APlayerEntity
{
    public FarmCat()
        : base("Bread Cat", "A simple loaf of bread.", maxHealth: 1, attackStrength: 0, cost: 1)
    {
        
    }

    public override void DoAction()
    {
        ResourceManager.Instance.IncreaseResources(1);
    }
}