using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Triggered when a character interacts with another character


[RequireComponent(typeof(CharacterStats))] //make sure we actually have stats


public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f; //interval between attacks
    private float attackCooldown = 0f; //timer till next attack

    public float attackDelay = .6f;

    public event System.Action OnAttack;

    CharacterStats myStats;

    private void Start()
    {
        //grab the stats of this character
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime; //reduce cooldown per second as it's a timer 
    }

    //takes the stats of the target
    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f) // if there is no cooldown on attacking
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 1f / attackSpeed; //put attack back on cooldown
        }
   
    }

    IEnumerator DoDamage (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        //damage the target based on the damage value of the attacking character
        stats.TakeDamage(myStats.damage.GetValue());
    }
}
