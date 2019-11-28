using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Triggered when a character interacts with another character


[RequireComponent(typeof(CharacterStats))] //make sure we actually have stats


public class CharacterCombat : MonoBehaviour
{

    CharacterStats myStats;

    private void Start()
    {
        //grab the stats of this character
        myStats = GetComponent<CharacterStats>();
    }
    //takes the stats of the target
    public void Attack(CharacterStats targetStats)
    {
        //damage the target based on the damage value of the attacking character
        targetStats.TakeDamage(myStats.damage.GetValue());
    }
}
