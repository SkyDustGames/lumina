using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] bool enemyBullet = false;

    private void OnCollisionEnter2D(Collision2D other) {
        if (enemyBullet && other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<PlayerHealth>().Damage();

        transform.SpawnParticle(0);
        Destroy(gameObject);
    }
}