using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager instance;

    private void Awake() {
        instance = this;
    }

    public Transform generationArea, dragParentDummy;
    public AdditionalActionsMenuManager additionalActionsMenu;
    private GameObject draggedItem, dropSlot;

    

    public void Start() {
        CloseAdditionalActions();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        InventoryManager inventoryManager = player.GetComponent<InventoryManager>();
        for (int i=0; i<inventoryManager.items.Count; i++) {
            GameObject objectToBeCreated = Resources.Load("InventoryItemUnit") as GameObject;

            Transform creationSlot = null;
            for (int j=0; j<generationArea.childCount; j++) {
                if (generationArea.GetChild(j).childCount==0) {
                    creationSlot = generationArea.GetChild(j);
                }
            }

            if (creationSlot) {
                GameObject inventoryItemUnit = Instantiate(objectToBeCreated, creationSlot);
                inventoryItemUnit.transform.localPosition = Vector3.zero;
                inventoryItemUnit.transform.localRotation = Quaternion.identity;

                InventoryItemUnitManager inventoryItemUnitManager = inventoryItemUnit.GetComponent<InventoryItemUnitManager>();
                inventoryItemUnitManager.Initiate(inventoryManager.items[i]);
            }
        }
    }

    public void HandleParentingOnDragStart(GameObject item) {
        item.transform.SetParent(dragParentDummy);
    }

    public void RegisterDraggedObject(GameObject item) {
        draggedItem = item;
    }
    public void UnregisterDraggedItem() {
        draggedItem = null;
    }
    public void RegisterSlotForDraggedObject(GameObject slot) {
        dropSlot = slot;
    }
    public void UnregisterSlotForDraggedObject(GameObject slot) {
        // if (dropSlot != slot)
        //     return;
        dropSlot = null;
    }

    public bool IsThereADropSlotUnderCursor() {
        return dropSlot!=null;
    }
    public Transform GetDroppableSlot() {
        return dropSlot.transform;
    } 

    public void ShowAdditionalActions(Vector3 clickedPosition, InventoryItem anItem, InventoryItemUnitManager inventoryItemUnitManager) {
        additionalActionsMenu.gameObject.SetActive(true);
        additionalActionsMenu.SetItemInfo(anItem, inventoryItemUnitManager);
        additionalActionsMenu.transform.position = clickedPosition;
    }
    public void CloseAdditionalActions() {
        additionalActionsMenu.gameObject.SetActive(false);
    }
}
