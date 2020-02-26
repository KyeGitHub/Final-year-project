using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public bool isStackable;
    public int count;


    public virtual void Use()
    {
        //use the item

        Debug.Log("USING " + name);
    }
    
    public void RemoveFromInventory()
    {
        if(isStackable & count > 1)
        {
            count--;
        }

        else
        {
            Inventory.instance.Remove(this);
        }
        
    }
}
