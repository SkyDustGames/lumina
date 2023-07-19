
using UnityEngine;

public class BreakableBlock : MonoBehaviour {
    
    [SerializeField] int health = 3;
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRenderer;

    public void Damage() {
        health--;
        if (health <= 0) {
            transform.SpawnParticle(1, false);
            Destroy(gameObject);
            return;
        }

        transform.SpawnParticle(0, false);
        spriteRenderer.sprite = sprites[health - 1];
    }
}