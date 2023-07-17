using UnityEngine;

public abstract class Boss : MonoBehaviour {

    protected Transform player;
    [SerializeField] protected float health = 3f;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            health--;
            OnHit();

            if (health <= 0)
                LevelManager.instance.GoToNextLevel();
        }
    }
    
    public abstract void StartFight();
    public virtual void OnHit() {}
}