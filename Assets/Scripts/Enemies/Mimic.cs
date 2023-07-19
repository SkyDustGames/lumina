using UnityEngine;
using System.Collections;
using DG.Tweening;

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

        StartCoroutine(IAnimate());
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

    private IEnumerator IAnimate() {
        while (!enemyActive) {
            transform.DOShakePosition(Random.Range(1f, 2f), .1f, fadeOut: false);
            yield return Helpers.Wait(Random.Range(5f, 10f));
        }
    }
}