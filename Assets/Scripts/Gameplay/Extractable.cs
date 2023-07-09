using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Extractable : MonoBehaviour {

    [SerializeField] float health;
    [SerializeField] float speed;
    [SerializeField] float ySpeed;
    [SerializeField] Item item, stone;
    [SerializeField] int dropCount;
    [SerializeField] Drop dropPrefab;
    float maxHealth;

    private void Awake() {
        maxHealth = health;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            Helpers.Camera.Shake(.1f, .1f);
            transform.SpawnParticle(health - 1 <= 0 ? 1 : 0);

            health -= 1;
            transform.DOScale(Vector3.one * (health / maxHealth) * 1.75f, .5f);

            if (health <= 0) {
                int stoneCount = Random.Range(0, dropCount / 2);
                dropCount -= stoneCount;

                for (int i = 0; i < dropCount; i++){
                    Drop drop = Instantiate(dropPrefab, transform.position, transform.rotation);
                    drop.SetItem(item);
 
                    Rigidbody2D rb = drop.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed)), ForceMode2D.Impulse);
                }

                for (int i = 0; i < stoneCount; i++){
                    Drop drop = Instantiate(dropPrefab, transform.position, transform.rotation);
                    drop.SetItem(stone);
 
                    Rigidbody2D rb = drop.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed)), ForceMode2D.Impulse);
                }

                Destroy(gameObject);
            }

            Destroy(other.gameObject);
        }
    }
}