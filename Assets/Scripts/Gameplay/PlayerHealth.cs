using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    
    [SerializeField] float health;
    [SerializeField] Slider slider;

    private void Awake() {
        slider.maxValue = health;
        slider.value = health;
    }

    public void Damage(float amount = 1) {
        health -= amount;
        slider.DOValue(health, .5f);
        Helpers.Camera.Shake(.1f, .1f);

        if (health <= 0) {
            transform.SpawnParticle(1, false);
            Scenes.Reload();
            Destroy(gameObject);

            return;
        }

        transform.SpawnParticle(0, false);
    }
}