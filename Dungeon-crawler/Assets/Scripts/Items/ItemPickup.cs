using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
   
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        int amount= 1;
        if (item.isStackable)
            amount = Random.Range(1, 6);
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item, amount);
        if (wasPickedUp)
            Destroy(gameObject);
    }

}
