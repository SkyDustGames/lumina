using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Extractable : MonoBehaviour {

    [SerializeField] float health;
    [SerializeField] float speed;
    [SerializeField] float ySpeed;
    [SerializeField] Item item;
    [SerializeField] int dropCount;
    [SerializeField] Drop dropPrefab;
    float maxHealth;
    SpriteRenderer spriteRenderer;
    Shader shaderText;
	Shader shaderSpritesDefault;

    private void Awake() {
        maxHealth = health;
        spriteRenderer = GetComponent<SpriteRenderer>();
        shaderText = Shader.Find("GUI/Text Shader");
		shaderSpritesDefault = spriteRenderer.material.shader;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            health -= 1;
            transform.DOScale(Vector3.one * (health / maxHealth) * 1.75f, .5f);

            Color c = spriteRenderer.color;
            spriteRenderer.material.shader = shaderText;
            spriteRenderer.color = Color.white;

            if (health <= 0) {
                for (int i = 0; i < dropCount; i++){
                    Drop drop = Instantiate(dropPrefab, transform.position, transform.rotation);
                    drop.SetItem(item);
 
                    Rigidbody2D rb = drop.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed)), ForceMode2D.Impulse);
                }

                Destroy(gameObject);
            }

            Destroy(other.gameObject);
            StartCoroutine(IResetColor(c));
        }
    }

    private IEnumerator IResetColor(Color c) {
        yield return Helpers.Wait(.1f);
        spriteRenderer.material.shader = shaderSpritesDefault;
        spriteRenderer.color = c;
    }
}