using UnityEngine;

public abstract class APlayerEntity : ABaseEntity
{
    protected APlayerEntity(string name, string description, int maxHealth, int attackStrength, int cost)
        : base(name, description, maxHealth, attackStrength)
    {
        Cost = cost;
    }

    public int Cost { get; }

    public abstract void DoAction();

    public override void TakeDamage(int incomingDamage)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        base.TakeDamage(incomingDamage);
    }
}
