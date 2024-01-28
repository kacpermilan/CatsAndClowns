using UnityEngine;

public class MarshmallowBullet : MonoBehaviour
{
    private int _damage;

    private Rigidbody2D _rigidbody2D;

    private bool _buffed;

    [SerializeField] 
    private Sprite _fireMarshmallow;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public void LaunchBullet(int damage, float launchForce)
    {
        _damage = damage;
        _rigidbody2D.AddForce(new Vector2(launchForce, 0), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BoosterCat _) && !_buffed)
        {
            _buffed = true;
            _damage += 1;
            _spriteRenderer.sprite = _fireMarshmallow;
        }

        if (collision.TryGetComponent(out AEnemyEntity enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }

        if (collision.TryGetComponent(out EnemyBoss boss))
        {
            boss.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
