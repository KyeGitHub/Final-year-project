using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public GameManager gm;
    public bool wasPickedUp = false;
    public bool destroyOnPickUp = true;
    public int amount = 1;
    private void Awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();

    }

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    public virtual void PickUp()
    {

        Debug.Log(item.name);
        if (item.isStackable)
            amount = Random.Range(1, 6);
        Debug.Log("Picking up " + item.name);

        wasPickedUp = Inventory.instance.Add(item, amount);

        if (wasPickedUp && destroyOnPickUp)
        {
            Debug.Log(wasPickedUp + " " + destroyOnPickUp);
            Destroy(this.gameObject);
        }



    }

}
