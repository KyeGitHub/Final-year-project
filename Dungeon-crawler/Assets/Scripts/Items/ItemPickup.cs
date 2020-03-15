using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    private GameManager gm;
    private ParticleSystem particles;
    private void Awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        particles = GetComponentInChildren<ParticleSystem>();
    }

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        int amount = 1;
        if (item.isStackable)
            amount = Random.Range(1, 6);
        Debug.Log("Picking up " + item.name);
        Messenger.Instance.CreateMessage(gm.doDestroy, gm.destroyChatTime, gm.chatMessagePrefab, gm.chatMessageParent, "Picked up " + item.name, Color.magenta);
        bool wasPickedUp = Inventory.instance.Add(item, amount);
        if (wasPickedUp && this.tag != "Fishing Spot")
            Destroy(gameObject);
        if (wasPickedUp && this.tag == "Fishing Spot" && particles != null)
        {
            particles.Stop();
        }
    }

}
