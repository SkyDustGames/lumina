using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public abstract class Boss : MonoBehaviour {

    protected Transform player;
    [SerializeField] protected float health = 3f;
    [SerializeField] protected Slider slider;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        slider.maxValue = health;
        slider.value = health;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            health--;
            slider.DOValue(health, .5f);
            OnHit();

            if (health <= 0) {
                transform.SpawnParticle(1, false);
                Destroy(gameObject);
                LevelManager.instance.GoToNextLevel();
            }
        }
    }
    
    public abstract void StartFight();
    public virtual void OnHit() {}
}