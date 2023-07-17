using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Majoris : Boss {

    [SerializeField] SpriteRenderer eyeSprite;
    [SerializeField] Rigidbody2D sword;
    [SerializeField] float time;
    [SerializeField] float swordSpeed;
    [SerializeField] Sprite circle;
    [HideInInspector] public int state;
    SpriteRenderer spriteRenderer;
    Collider2D collider2d;
    float timer;
    bool active;

    private void Start() {
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void StartFight() {
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
            break;
        }

        timer = 0;
    }

    public override void OnHit() {
        StartCoroutine(IOnHit());
    }

    private IEnumerator IOnHit() {
        Sprite sprite = spriteRenderer.sprite;
        int sortingOrder = spriteRenderer.sortingOrder;

        spriteRenderer.sprite = circle;
        spriteRenderer.sortingOrder = 3;

        yield return Helpers.Wait(.1f);

        StateChange();
        state++;

        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingOrder = sortingOrder;
    }

    private IEnumerator IStartFight() {
        eyeSprite.DOColor(Color.black, 1.5f);
        yield return Helpers.Wait(2);
        active = true;
    }
}