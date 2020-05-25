using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Image icon;
    public Button removeButton;
    public Text amount;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

        if (item.isStackable)
        {
            amount.enabled = true;
            amount.text = item.count.ToString();
        }
        else
            amount.enabled = false;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        if (amount != null)
            amount.enabled = false;
    }
  
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    } 
   
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item != null)
            Tooltip.ShowToolTip_Static(item.GetTooltip());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideToolTip_Static();
    }

}
