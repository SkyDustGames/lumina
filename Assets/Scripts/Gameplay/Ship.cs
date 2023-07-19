using UnityEngine;
using DG.Tweening;
using System.Collections;
using TMPro;

public class Ship : MonoBehaviour {

    [SerializeField] PlayerInventory.InventoryItem[] neededItems;
    [SerializeField] Sprite[] damageLevels;
    [SerializeField] SpriteRenderer damage;
    [SerializeField] SpriteRenderer popup;
    [SerializeField] TextMeshPro required;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
            popup.DOFade(1f, .5f);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player")) {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            int amount = 0;
            foreach (var item in neededItems) {
                if (item.value <= 0) {
                    amount++;
                    continue;
                }

                PlayerInventory.InventoryItem i = inventory.GetItem(item.item);
                if (i == null) continue;

                item.value -= i.value;
                inventory.UpdateItem(i, -i.value);

                if (item.value <= 0) amount++;
            }

            damage.sprite = damageLevels[amount];
            Helpers.Camera.Shake(.1f, .1f);
            transform.SpawnParticle(1, playSound: false);

            if (amount >= neededItems.Length) {
                LevelManager.instance.GoToNextLevel();
                AudioManager.instance.PlaySound("ShipDone");
            } else {
                StartCoroutine(ShowRequiredItems());
                AudioManager.instance.PlaySound("ShipNotDone");
            }
        }
    }

    private IEnumerator ShowRequiredItems() {
        string str = "You need ";
        foreach (PlayerInventory.InventoryItem item in neededItems) {
            if (item.value <= 0) continue;
            str += item.value + " " + item.item.name + ", ";
        }
        str = str.Substring(0, str.Length - 2) + ".";
        required.text = str;

        required.DOFade(1f, .5f);
        yield return new WaitForSeconds(3f);
        required.DOFade(0f, .5f);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
            popup.DOFade(0f, .5f);
    }
}