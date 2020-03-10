using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
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

    public int space = 20;

    public List<Item> items = new List<Item>();


    public bool Add (Item item, int amount)
    {
        Debug.Log("In add function");
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }

            if (item.isStackable && items.Contains(item))
            {
                foreach (Item a in items)
                {
                    if (a.name == item.name)
                    {
                        a.count+= amount;
                        Debug.Log("Incremented existing item by: "+amount+" to " + a.count);
                        if (onItemChangedCallBack != null)
                            onItemChangedCallBack.Invoke();
                        return true;
                    }
                }
            }
            else if (item.isStackable && !items.Contains(item))
            {
                items.Add(item);
                item.count = amount;
            }
            else
            {
                items.Add(item);
                item.count = 1;
            }
            
            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }

        return true;
    }


    public void Remove(Item item)
    {
        
        if (!item.isStackable | item.count == 1)
        {
            items.Remove(item);
            Debug.Log("removing item: " + item.name);
        }
            
        else
        {
            item.count--;
            Debug.Log("lowering item count of: " + item.name);
        }
            
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
