using UnityEngine;

public class Drop : MonoBehaviour {

    [SerializeField] Item item;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerInventory>().AddItem(item);
            Destroy(gameObject);
        }
    }
}