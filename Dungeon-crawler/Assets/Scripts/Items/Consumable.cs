using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
    [SerializeField] private Rarity rarity;
    [SerializeField] private string useText = "Something";
    public Rarity Rarity { get { return rarity; } }

    [SerializeField] private int heal;
    private GameObject player;
    PlayerStats myStats;

    private void Awake()
    {
        
    }
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
}
