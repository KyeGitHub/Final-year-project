using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : ItemPickup
{
    private ParticleSystem particles;



    private void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        gm = GameObject.FindObjectOfType<GameManager>();
        destroyOnPickUp = false;

    }
    public override void PickUp()
    {
        item = GetComponent<FishingSpot>().item;
        base.PickUp();
        if (wasPickedUp)
        {
            Debug.Log(item.name);
            Messenger.Instance.CreateMessage(gm.doDestroy, gm.destroyChatTime, gm.chatMessagePrefab, gm.chatMessageParent, "Picked up " + amount + " " + item.name, Color.magenta);
            particles.Stop();
            Destroy(GetComponent<FishingSpot>());
        }

    }
}
