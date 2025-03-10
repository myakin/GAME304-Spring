using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData) {
        InventoryUIManager.instance.RegisterSlotForDraggedObject(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData) {
        InventoryUIManager.instance.UnregisterSlotForDraggedObject(gameObject);
    }
}
