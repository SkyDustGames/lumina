using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class Ship : MonoBehaviour {

    [SerializeField] PlayerInventory.InventoryItem[] neededItems;
    [SerializeField] SpriteRenderer popup; 

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
            popup.DOFade(1f, .5f);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player")) {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            int correctItems = 0;
            foreach (var item in neededItems) {
                PlayerInventory.InventoryItem i = inventory.GetItem(item.item);
                if (i == null) continue;

                if (i.value >= item.value)
                    correctItems++;
            }

            if (correctItems >= neededItems.Length)
                LevelManager.instance.GoToNextLevel();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
            popup.DOFade(0f, .5f);
    }
}