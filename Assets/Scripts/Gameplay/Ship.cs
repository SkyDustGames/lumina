using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class Ship : MonoBehaviour {

    [SerializeField] PlayerInventory.InventoryItem[] neededItems;
    [SerializeField] Sprite[] damageLevels;
    [SerializeField] SpriteRenderer damage;
    [SerializeField] SpriteRenderer popup;

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
            transform.SpawnParticle(1, false);

            if (amount >= neededItems.Length) LevelManager.instance.GoToNextLevel();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
            popup.DOFade(0f, .5f);
    }
}