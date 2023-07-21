using System.Collections;
using UnityEngine;

public class CrimsonActivator : Enemy {

    [Header("CrimsonActivator.cs")]
    [SerializeField] GameObject crimsonPrefab;
    [SerializeField] Sprite circle;
    [SerializeField] float rotationSpeed;
    SpriteRenderer spriteRenderer;
    Sprite sprite;

    public override void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite = spriteRenderer.sprite;
        base.Awake();
    }

    public override void Update() {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }

    public override void OnHit() {
        StartCoroutine(IOnHit());
    }

    public override void OnDeath() {
        Instantiate(crimsonPrefab, transform.position, Quaternion.identity);
    }

    private IEnumerator IOnHit() {
        spriteRenderer.sprite = circle;
        yield return Helpers.Wait(.1f);
        spriteRenderer.sprite = sprite;
    }
}