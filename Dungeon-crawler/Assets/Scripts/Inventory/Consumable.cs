using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
    public int heal;
    public GameObject player;
    PlayerStats myStats;

    private void Awake()
    {
        // doesnt work for some reason
        //player = GameObject.FindGameObjectWithTag("Player");
        //myStats = player.GetComponent<PlayerStats>();
        //Debug.Log("HERE: " + myStats.currentHealth);
    }
    public override void Use()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myStats = player.GetComponent<PlayerStats>();
        base.Use();
        // Increase health by 15
        myStats.Heal(heal);
        // remove item
        Inventory.instance.Remove(this);
    }
}
