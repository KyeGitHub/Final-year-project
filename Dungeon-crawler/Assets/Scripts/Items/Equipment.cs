using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equiptment", menuName = "Inventory/Equipment")]

public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public int armourModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        //equip item
        EquipmentManager.instance.Equip(this);
        //remove from invent  
        RemoveFromInentory();
    }

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet};