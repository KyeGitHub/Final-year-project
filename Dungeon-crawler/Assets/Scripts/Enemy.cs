using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))] //make sure we actually have stats
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>(); //grab the stats of this character
        interactionTransform = GetComponent<Transform>();
    }

    //Called when enemy is interacted with
    public override void Interact()
    {
        //Do normal interact function
        base.Interact();

        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();

        //attack
        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }
}
