using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddToInventory(InventoryItem item) {
        for (int i=0; i<items.Count; i++) {
            if (items[i].itemName == item.itemName) {
                items[i].amount+=item.amount;
                return;
            }
        }
        items.Add(item);
    }

    public void AddToInventory(GameObject obj) {
        InventoryItemData data = obj.GetComponent<InventoryItemData>();
        InventoryItem item = new InventoryItem(data.itemName, data.amount, data.definition, data.droppable, data.iconName, data.prefabName);
        AddToInventory(item);
        Destroy(obj);
    }

    public void RemoveItem(InventoryItem item) {
        for (int i=0; i<items.Count; i++) {
            if (items[i].IsSame(item)) {
                items[i].amount--;
                if (items[i].amount <= 0) {
                    items.RemoveAt(i);
                }
                break;
            }
        }
    }

    private bool IsItemExisting(InventoryItem item) {
        for (int i=0; i<items.Count; i++) {
            if (items[i].itemName == item.itemName) {
                return true;
            }
        }
        return false;
    }



}
