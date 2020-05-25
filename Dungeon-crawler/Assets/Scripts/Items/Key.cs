using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Key")]
public class Key : Item
{
    public override void Use()
    {
     
    }

    public override string GetTooltip()
    {
        string tooltipText;

        StringBuilder builder = new StringBuilder();
        builder.Append(name).AppendLine();
        builder.Append(useText).AppendLine();


        tooltipText = builder.ToString();
        return tooltipText;

    }
}
