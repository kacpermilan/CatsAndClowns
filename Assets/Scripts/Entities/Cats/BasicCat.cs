using UnityEngine;

public class BasicCat : APlayerEntity
{
    public GameObject MarshmallowBulletPrefab;
    private readonly float _launchForce;

    public BasicCat()
        : base("Cat Wizard", "A mystical cat with magical powers.", maxHealth: 2, attackStrength: 2, cost: 1)
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
        bullet.GetComponent<MarshmallowBullet>().LaunchBullet(_attackStrength, _launchForce);
    }
}