using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

    public Dictionary<Item, int> items = new Dictionary<Item, int>();
    
    public void AddItem(Item item) {
        if (items.ContainsKey(item))
            UpdateItem(item);
        else
            Add(item);
    }

    private void UpdateItem(Item item) {
        items[item]++;
        Debug.Log(items[item]);
    }

    private void Add(Item item) {
        items.Add(item, 1);
        Debug.Log(items[item]);
    }
}