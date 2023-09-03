using UnityEngine;

public class Drop : MonoBehaviour {

    [SerializeField] Item item;
    [SerializeField] float speed;
    SpriteRenderer spriteRenderer;
    static Transform player;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        if (item != null)
            SetItem(item);
    }

    public void SetItem(Item item) {
        spriteRenderer.sprite = item.sprite;
        gameObject.name = item.name + "Drop";
        this.item = item;
    }

    private void Update() {
        transform.localScale -= Vector3.one * 0.1f * Time.deltaTime;
        if (transform.localScale.x <= 0)
            Destroy(gameObject);

        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < 5f)
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            transform.SpawnParticle(0, playSound: false);
            AudioManager.instance.PlaySound("Collect");
            other.gameObject.GetComponent<PlayerInventory>().AddItem(item);
            Destroy(gameObject);
        }
    }
}