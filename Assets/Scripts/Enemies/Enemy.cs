using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    
    [Header("Enemy.cs")]
    [SerializeField] float health;
    [SerializeField] float speed;
    Transform player;
    protected bool enemyActive = true;

    public virtual void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void Update() {
        if (!enemyActive) return;

        if (player != null)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            health--;
            OnHit();

            if (health <= 0) {
                OnDeath();
                Destroy(gameObject);
            }

            Helpers.Camera.Shake(.1f, .1f);
            transform.SpawnParticle(health <= 0 ? 1 : 0);
        }

        if (other.gameObject.CompareTag("Player") && enemyActive) {
            OnDeath();

            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
            health.Damage();

            Helpers.Camera.Shake(.1f, .1f);
            transform.SpawnParticle(1);
            Destroy(gameObject);
        }
    }

    public abstract void OnDeath();
    public virtual void OnHit() {}
}