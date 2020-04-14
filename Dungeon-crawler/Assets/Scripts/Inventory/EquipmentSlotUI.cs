using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotUI : MonoBehaviour
{
    public Image icon;
    public Equipment item;

    public void AddItem(Equipment newItem)
    {
        item = newItem;
       
        if (!item.isDefaultItem)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
        }
            
        else
            icon.enabled = false;
    }
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        
    }

    public void OnRemoveButton()
    {
        if (!item.isDefaultItem)
            EquipmentManager.instance.Unequip((int)item.equipSlot);
            
        
    }

}

