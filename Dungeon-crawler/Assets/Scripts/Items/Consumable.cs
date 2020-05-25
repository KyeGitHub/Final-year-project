using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
    [SerializeField] private Rarity rarity;
    public Rarity Rarity { get { return rarity; } }

    [SerializeField] private int heal;
    private GameObject player;
    PlayerStats myStats;

    public override void Use()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myStats = player.GetComponent<PlayerStats>();
        base.Use();
        // Increase health by 15
        myStats.Heal(heal);
        // Remove item
        Inventory.instance.Remove(this);
    }

    public override string GetTooltip()
    {
        string tooltipText;

        StringBuilder builder = new StringBuilder();
        builder.Append(name).AppendLine();
        if (rarity != null)
            builder.Append(rarity.name).AppendLine();
        builder.Append(useText).AppendLine();


        tooltipText = builder.ToString();
        return tooltipText;

    }
}
