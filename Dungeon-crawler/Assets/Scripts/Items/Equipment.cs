using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


[CreateAssetMenu(fileName = "New Equiptment", menuName = "Inventory/Equipment")]

public class Equipment : Item
{
    [SerializeField] private Rarity rarity;

    public Rarity Rarity { get { return rarity; } }
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armourModifier;
    public int damageModifier;

   
    public override void Use()
    {
        base.Use();
        // equip item
        EquipmentManager.instance.Equip(this);
        // remove from invent  
        RemoveFromInventory();
        Tooltip.HideToolTip_Static();
    }

    public override string GetTooltip()
    {
        string tooltipText;

        StringBuilder builder = new StringBuilder();
        builder.Append(name).AppendLine();
        if (rarity !=null)
            builder.Append(rarity.name).Append(" ").Append(equipSlot.ToString()).AppendLine();
        builder.Append("Damage: ").Append(damageModifier).AppendLine();
        builder.Append("Armour: ").Append(armourModifier).AppendLine();
       

        tooltipText = builder.ToString();
        return tooltipText;

    }
}

public enum EquipmentSlot { Helmet, Chest, Legs, Weapon, Shield, Feet};
public enum EquipmentMeshRegion {Legs, Arms, Torso}; // Corresponds to body blendshapes.