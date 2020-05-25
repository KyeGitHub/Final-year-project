using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : Interactable
{
    [SerializeField]
    Key bossKey;
    private GameManager gm;
    public void Awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Called when enemy is interacted with
    public override void Interact()
    {
        if (Inventory.instance.Items.Contains(bossKey))
        {
            this.gameObject.SetActive(false);
            Inventory.instance.Remove(bossKey);
            Messenger.Instance.CreateMessage(gm.doDestroy, gm.destroyChatTime, gm.chatMessagePrefab, gm.chatMessageParent, "Good luck, you'll need it!", Color.red);
        }
        else
         Messenger.Instance.CreateMessage(gm.doDestroy, gm.destroyChatTime, gm.chatMessagePrefab, gm.chatMessageParent, "You need to find: " + bossKey.name, Color.red);
    }
}
