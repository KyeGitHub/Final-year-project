using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://www.youtube.com/watch?v=gZsJ_rG5hdo

[Serializable]
public struct ItemAmount
{
    public Item item;
    [Range(1, 999)]
    public int amount;

}
[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;

    public bool CanCraft(IItemContainer itemContainer)
    {
        foreach (ItemAmount itemAmount in Materials)
        {
            if (itemContainer.ItemCount(itemAmount.item) < itemAmount.amount)
            {
                return false;
            }
        }
        return true;
    }

    public void Craft(IItemContainer itemContainer)
    {
        if (CanCraft(itemContainer))
        {
            foreach (ItemAmount itemAmount in Materials)
            {
                for (int i = 0; i < itemAmount.amount; i++)
                {
                    itemContainer.Remove(itemAmount.item);
                }
            }

            foreach (ItemAmount itemAmount in Results)
            {
                for (int i = 0; i < itemAmount.amount; i++)
                {
                    itemContainer.Add(itemAmount.item, 1);
                }
            }
        }

    }
}
