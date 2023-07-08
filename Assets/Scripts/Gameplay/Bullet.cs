using UnityEngine;

public class Bullet : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Player")) {
            transform.SpawnParticle(0);
            Destroy(gameObject);
        }
    }
}