public class BoosterCat : APlayerEntity
{
    public BoosterCat()
        : base("Cat with a ball of jarn.", "I've got a ball of jarn!", maxHealth: 2, attackStrength: 0, cost: 2)
    {
        
    }

    public override void DoAction()
    {
        // Special ability -> buffing projectiles that pass through it
    }
}