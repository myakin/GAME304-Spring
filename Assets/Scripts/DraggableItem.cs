using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform oldParent;

    public void OnBeginDrag(PointerEventData eventData) {
        oldParent = transform.parent;
        InventoryUIManager.instance.HandleParentingOnDragStart(gameObject);
        InventoryUIManager.instance.RegisterDraggedObject(gameObject);
    }

    public void OnDrag(PointerEventData eventData) {
        Vector2 mousePos = Input.mousePosition;
        transform.position = mousePos;
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (InventoryUIManager.instance.IsThereADropSlotUnderCursor()) {
            transform.SetParent(InventoryUIManager.instance.GetDroppableSlot());
        } else {
            transform.SetParent(oldParent);
        }
        transform.localPosition = Vector3.zero;
        InventoryUIManager.instance.UnregisterDraggedItem();
        GetComponent<Image>().raycastTarget = true;
    }
}
