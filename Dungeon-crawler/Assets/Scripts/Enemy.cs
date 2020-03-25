using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))] //make sure we actually have stats
public class Enemy : Interactable
{
    PlayerManager playerManager;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        //interactionTransform = GetComponent<Transform>();
    }

    // Called when enemy is interacted with
    public override void Interact()
    {
        // Do normal interact function
        base.Interact();

        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        playerCombat.SetTarget(this);
    }
}
