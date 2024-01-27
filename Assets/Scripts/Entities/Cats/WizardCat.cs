using UnityEngine;
public class WizardCat : ACat, IPlaceableEntity
{
    [SerializeField] private float _cost;
    float IPlaceableEntity.Cost { get { return _cost; } set {_cost = value;} }
    
    public WizardCat()
        : base("Cat Wizard", "A mystical cat with magical powers.", maxHealth: 50, attackStrength: 10, cost: 3)
    {
        
    }



}