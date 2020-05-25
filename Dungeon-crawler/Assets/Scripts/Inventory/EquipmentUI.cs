using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform equipmentParent;
    public GameObject equipmentUI;
    EquipmentSlotUI[] slots;
    public EquipmentManager em;

    void Start()
    {
        slots = equipmentParent.GetComponentsInChildren<EquipmentSlotUI>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Equipment"))
        {
            equipmentUI.SetActive(!equipmentUI.activeSelf);
            if (!equipmentUI.activeSelf)
                Tooltip.HideToolTip_Static();
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < em.currentEquipment.Length)
            {
                if (!em.currentEquipment[i].isDefaultItem)
                {
                    slots[i].AddItem(em.currentEquipment[i]);
                }
            }

            else
            {
                slots[i].ClearSlot();
            }
        }
        Debug.Log("UPDATING EQUIPMENT UI");
    }
}
