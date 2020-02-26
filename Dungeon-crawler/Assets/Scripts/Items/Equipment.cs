using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equiptment", menuName = "Inventory/Equipment")]

public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armourModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        //equip item
        EquipmentManager.instance.Equip(this);
        //remove from invent  
        RemoveFromInventory();
    }

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet};
public enum EquipmentMeshRegion {Legs, Arms, Torso}; //Corresponds to body blendshapes.