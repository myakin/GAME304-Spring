using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int amount;
    public string definition;
    public bool droppable;
    public string iconName;
    public string prefabName;

    public InventoryItem() {}

    public InventoryItem(string itemName, int amount, string definition, bool droppable, string iconName, string prefabName) {
        this.itemName = itemName;
        this.amount = amount; 
        this.definition = definition;
        this.droppable = droppable;
        this.iconName = iconName;
        this.prefabName = prefabName;
    }

    public bool IsSame(InventoryItem item) {
        if (
            itemName == item.itemName && amount == item.amount && definition == item.definition && droppable == item.droppable
            &&
            iconName == item.iconName && prefabName == item.prefabName
        ) {
            return true;
        }
        return false;
    }

}
