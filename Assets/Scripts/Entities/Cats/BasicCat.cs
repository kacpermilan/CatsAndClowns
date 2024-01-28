using UnityEngine;

public class BasicCat : APlayerEntity
{
    public GameObject MarshmallowBulletPrefab;
    private readonly float _launchForce;

    public BasicCat()
        : base("Cat Wizard", "A mystical cat with magical powers.", maxHealth: 1, attackStrength: 1, cost: 2)
    {
        _launchForce = 10f;
    }

    public override void DoAction()
    {
        if (MarshmallowBulletPrefab == null)
        {
            return;
        }

        GameObject bullet = Instantiate(MarshmallowBulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<MarshmallowBullet>().LaunchBullet(attackStrength, _launchForce);
    }
}