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


    public bool Add (Item item)
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
                        a.count++;
                        Debug.Log("Incremented existing item to " + a.count);
                        if (onItemChangedCallBack != null)
                            onItemChangedCallBack.Invoke();
                        return true;
                    }
                }
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
        items.Remove(item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
