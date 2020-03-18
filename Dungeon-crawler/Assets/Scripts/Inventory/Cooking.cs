using UnityEngine;

public class Cooking : Interactable
{
    private GameManager gm;
    public Item rawItem;
    public Item cookedItem;

    public void Awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    public override void Interact()
    {
        Debug.Log("Interacting");
        base.Interact();
        Cook();
    }

    void Cook()
    {
        Debug.Log("In Cook");
        // check for raw items remove one and replace with cooked
        if (Inventory.instance.items.Contains(rawItem)) // if the player has any raw food
        {
            // remove raw
            if (rawItem.count > 1)
                rawItem.count--;
            else
                Inventory.instance.Remove(rawItem);
            // animation

            // add cooked
            Inventory.instance.Add(cookedItem, 1);
            Messenger.Instance.CreateMessage(gm.doDestroy, gm.destroyChatTime, gm.chatMessagePrefab, gm.chatMessageParent, "Cooked " + rawItem.name, Color.blue);
        }

    }
}
