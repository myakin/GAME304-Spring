using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryItemUnitManager : MonoBehaviour, IPointerClickHandler
{
    public Image iconImage;
    public Button itemButton;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI amount;
    
    private InventoryItem item;

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Right) {
            Vector3 clickedPosition = eventData.position;
            OpenActionsMenu(clickedPosition);
        } else if (eventData.button == PointerEventData.InputButton.Left) {
            CloseActionsMenu();
        }
    }

    public void Initiate(InventoryItem data) {
        this.item = data;

        // load the texture with [data.iconName]
        Sprite icon = Resources.Load<Sprite>("Icon_Rifle");

        // assign the loaded texture to iconImage object
        iconImage.sprite = icon;

        itemName.text = data.itemName;
        amount.text = data.amount.ToString();

        // assign button actions
        // itemButton.onClick.AddListener(OpenActionsMenu);
    }

    public void OpenActionsMenu(Vector3 clickedPosition) {
        // Vector3 clickedPosition = transform.position;
        InventoryUIManager.instance.ShowAdditionalActions(clickedPosition, item, this);
    }
    public void CloseActionsMenu() {
        InventoryUIManager.instance.CloseAdditionalActions();
    }

    public void UpdateAmount(InventoryItem data) {
        amount.text = data.amount.ToString();
    }

}