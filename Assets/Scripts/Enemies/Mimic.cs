using UnityEngine;

public class Mimic : Enemy {

    [Header("Mimic.cs")]
    [SerializeField] int dropCount;
    [SerializeField] float dropSpeed;
    [SerializeField] Drop dropPrefab;
    [SerializeField] Item item, stone;
    [SerializeField] Sprite gemActive;

    public override void Awake() {
        base.Awake();
        enemyActive = false;
    }

    public override void OnDeath() {
        int stoneCount = Random.Range(0, dropCount / 2);
        dropCount -= stoneCount;

        for (int i = 0; i < dropCount; i++){
            Drop drop = Instantiate(dropPrefab, transform.position, transform.rotation);
            drop.SetItem(item);

            Rigidbody2D rb = drop.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(Random.Range(-dropSpeed, dropSpeed), Random.Range(-dropSpeed, dropSpeed)), ForceMode2D.Impulse);
        }

        for (int i = 0; i < stoneCount; i++){
            Drop drop = Instantiate(dropPrefab, transform.position, transform.rotation);
            drop.SetItem(stone);

            Rigidbody2D rb = drop.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(Random.Range(-dropSpeed, dropSpeed), Random.Range(-dropSpeed, dropSpeed)), ForceMode2D.Impulse);
        }
    }

    public override void OnHit() {
        enemyActive = true;
        GetComponent<SpriteRenderer>().sprite = gemActive;
        GetComponent<Animator>().enabled = true;
    }
}