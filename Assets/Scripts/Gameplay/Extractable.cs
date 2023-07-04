using UnityEngine;
using DG.Tweening;

public class Extractable : MonoBehaviour {

    [SerializeField] SpriteRenderer popup;
    [SerializeField] float health;
    [SerializeField] float speed;
    [SerializeField] float ySpeed;
    [SerializeField] Item item;
    [SerializeField] int dropCount;
    [SerializeField] Drop dropPrefab;
    float maxHealth;

    private void Awake() {
        maxHealth = health;
    }

    private void OnMouseEnter() {
        popup.DOFade(1f, .5f);
    }

    private void OnMouseExit() {
        popup.DOFade(0f, .5f);
    }

    private void OnMouseDown() {
        health -= 1;
        transform.DOScale(Vector3.one * (health / maxHealth) * 1.5f, .5f);

        if (health <= 0) {
            for (int i = 0; i < dropCount; i++){
                Drop drop = Instantiate(dropPrefab, transform.position, transform.rotation);
                drop.SetItem(item);

                Rigidbody2D rb = drop.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(Random.Range(-speed, speed), ySpeed), ForceMode2D.Impulse);
            }

            Destroy(gameObject);
        }
    }
}