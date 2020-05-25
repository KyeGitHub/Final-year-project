using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemiBossStats : CharacterStats
{
    [SerializeField]
    Key bossKey;
    [SerializeField]
    Item crystals;
    [SerializeField]
    Item rawFish;
    public override void Die()
    {
        //call die function
        base.Die();
        if(!Inventory.instance.Items.Contains(bossKey))
            Inventory.instance.Add(bossKey, 1);
        Inventory.instance.Add(crystals, Random.Range(0, 6));
        Inventory.instance.Add(rawFish, Random.Range(0, 6));
        Destroy(gameObject);
    }
}
