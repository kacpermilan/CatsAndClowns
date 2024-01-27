using UnityEngine;

public class MarshmallowBullet : MonoBehaviour
{
    private int _damage;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void LaunchBullet(int damage, float launchForce)
    {
        _damage = damage;
        _rigidbody2D.AddForce(new Vector2(launchForce, 0), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AEnemyEntity enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
