using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IItemContainer
{
    #region singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 18;

    public List<Item> Items = new List<Item>();


    public bool Add(Item item, int amount)
    {
        Debug.Log("In add function");
        if (!item.isDefaultItem)
        {
            if (IsFull())
            {
                Debug.Log("Not enough room.");
                return false;
            }

            if (item.isStackable && Items.Contains(item))
            {
                foreach (Item a in Items)
                {
                    if (a.name == item.name)
                    {
                        a.count += amount;
                        Debug.Log("Incremented existing item by: " + amount + " to " + a.count);
                        if (onItemChangedCallBack != null)
                            onItemChangedCallBack.Invoke();
                        return true;
                    }
                }
            }
            else if (item.isStackable && !Items.Contains(item))
            {
                Items.Add(item);
                item.count = amount;
            }
            else
            {
                Items.Add(item);
                item.count = 1;
            }

            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }

        return true;
    }


    public bool Remove(Item item)
    {

        if (!item.isStackable | item.count == 1)
        {
            Items.Remove(item);
            Debug.Log("removing item: " + item.name);
        }

        else
        {
            item.count--;
            Debug.Log("lowering item count of: " + item.name);
        }

        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
            return true;
        }
        return false;
    }

    public bool ContainsItem(Item item)
    {

        if (Items.Count != 0)
        {
            return true;
        }
        return false;

    }
    public bool IsFull()
    {
        if (Items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return true;
        }
        return false;
    }

    public int ItemCount(Item item)
    {
        int amount = 0;
        foreach (Item a in Items)
        {
            if (a.name == item.name)
            {
                amount += item.count;
            }
        }

        return amount;

    }
}
