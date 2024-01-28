using UnityEngine;

public class LaserCat : APlayerEntity
{
    public bool OnCooldown { get; private set; }
    public GameObject LaserBulletPrefab;
    private readonly float _launchForce;

    public LaserCat()
        : base("Rainbow Cat", "Ima Firing My Lazer.", maxHealth: 1, attackStrength: 2, cost: 3)
    {
        _launchForce = 20f;
    }

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("IsResting", OnCooldown);
    }

    public override void DoAction()
    {
        if (LaserBulletPrefab == null)
        {
            return;
        }

        if (OnCooldown)
        {
            OnCooldown = false;
            return;
        }

        GameObject bullet = Instantiate(LaserBulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<RainbowBullet>().LaunchBullet(attackStrength, _launchForce);
        OnCooldown = true;
    }
}