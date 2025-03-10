using UnityEngine;
using UnityEngine.UI;

public class AdditionalActionsMenuManager : MonoBehaviour
{
    public Button dropbutton, destroyButton;
    private InventoryItem item;
    private InventoryItemUnitManager inventoryItemUnitManager;

    private void Start() {
        dropbutton.onClick.AddListener(DropObject);
        destroyButton.onClick.AddListener(DestroyObject);
    }

    public void SetItemInfo(InventoryItem item, InventoryItemUnitManager inventoryItemUnitManager) {
        this.item = item;
        this.inventoryItemUnitManager = inventoryItemUnitManager;
    }

    private void DropObject() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 spawnPos = player.transform.position + player.transform.forward * 1.1f;
        RaycastHit hit;
        if (Physics.Raycast(spawnPos + player.transform.up * 2, Vector3.down, out hit, 10, 1<<0, QueryTriggerInteraction.Ignore )) {
            spawnPos = hit.point + player.transform.up * 1;
        }

        GameObject droppedObjectInResources = Resources.Load(item.prefabName) as GameObject;
        GameObject droppedObject = Instantiate(droppedObjectInResources, spawnPos, player.transform.rotation);
        droppedObject.AddComponent<DroppedItemPhysics>();

        player.GetComponent<InventoryManager>().RemoveItem(item);

        if (item.amount == 0)
            Destroy(inventoryItemUnitManager.gameObject);
        else
            inventoryItemUnitManager.UpdateAmount(item);

        InventoryUIManager.instance.CloseAdditionalActions();
    }

    private void DestroyObject() {

    }

}
