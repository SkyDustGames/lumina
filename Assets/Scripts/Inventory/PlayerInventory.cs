using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    [System.Serializable]
    public class InventoryItem {

        public Item item;
        public int value;
        public TextMeshProUGUI valueText;
        public Image image;

        public InventoryItem(Item item) {
            this.item = item;
            this.value = 1;
        }

        public override string ToString() {
            return item.name + "[" + value + "]";
        }
    }

    [SerializeField] GameObject textPrefab;
    [SerializeField] Transform inventory;

    public List<InventoryItem> items = new List<InventoryItem>();
    
    public void AddItem(Item item) {
        foreach (InventoryItem inventoryItem in items) {
            if (inventoryItem.item.Equals(item)) {
                UpdateItem(inventoryItem);
                return;
            }
        }

        Add(new InventoryItem(item));
    }

    private void UpdateItem(InventoryItem item) {
        item.value++;
        item.valueText.text = "" + item.value;
    }

    private void Add(InventoryItem item) {
        items.Add(item);
        
        GameObject obj = Instantiate(textPrefab, inventory);

        item.valueText = obj.GetComponentInChildren<TextMeshProUGUI>();
        item.valueText.text = "1";

        item.image = obj.GetComponentInChildren<Image>();
        item.image.sprite = item.item.sprite;
    }
}