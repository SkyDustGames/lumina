using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Majoris : Boss {

    [SerializeField] SpriteRenderer eyeSprite;
    [SerializeField] Rigidbody2D sword;
    [SerializeField] float time;
    [SerializeField] float swordSpeed;
    [SerializeField] Sprite circle;
    [SerializeField] GameObject destructibleBlock;
    [SerializeField] Transform blocks;
    [SerializeField] Vector2 min, max;
    [SerializeField] int blockCount;
    [HideInInspector] public int state;
    SpriteRenderer spriteRenderer;
    Collider2D collider2d;
    float timer;
    bool active;
    int hitCount;

    private void Start() {
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void StartFight() {
        StartCoroutine(ISpawnBlocks());
        StartCoroutine(IStartFight());
    }

    private void Update() {
        eyeSprite.transform.parent.LookAt2D(player);
        if (state == 0) sword.transform.LookAt2D(player);

        if (!active) return;

        timer += Time.deltaTime;
        if (timer >= time) {
            StateChange();
            state++;
        }
    }

    public void StateChange() {
        switch (state) {
            case 0:
            sword.bodyType = RigidbodyType2D.Dynamic;
            sword.AddForce(sword.transform.right * swordSpeed, ForceMode2D.Impulse);
            time /= 2;
            break;

            case 1:
            time *= 2;
            collider2d.enabled = true;
            transform.DOLocalMove(sword.transform.localPosition, 1f);
            break;

            case 2:
            collider2d.enabled = false;
            transform.DOLocalMove(Vector3.zero, 1f);
            sword.transform.DOLocalMove(new(3, 0, 0), 1f);
            state = -1;
            StartCoroutine(ISpawnBlocks());
            break;
        }

        timer = 0;
    }

    public override void OnHit() {
        StartCoroutine(IOnHit());
    }

    private IEnumerator IOnHit() {
        hitCount++;
        if (hitCount >= 3) {
            hitCount = 0;
            StateChange();
            state++;
        }

        Sprite sprite = spriteRenderer.sprite;
        int sortingOrder = spriteRenderer.sortingOrder;

        spriteRenderer.sprite = circle;
        spriteRenderer.sortingOrder = 3;

        yield return Helpers.Wait(.1f);

        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingOrder = sortingOrder;
    }

    private IEnumerator IStartFight() {
        eyeSprite.DOColor(Color.black, 1.5f);
        yield return Helpers.Wait(2);
        active = true;
    }

    private IEnumerator ISpawnBlocks() {
        int j = blockCount - blocks.childCount;
        for (int i = 0; i < j; i++) {
            Instantiate(destructibleBlock, new(Random.Range(min.x, max.x), Random.Range(min.y, max.y)), Quaternion.Euler(0, 0, Random.Range(0, 360f)), blocks);
            yield return new WaitForSeconds(.1f);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(min.x, min.y), new Vector2(max.x, max.y));
    }
}