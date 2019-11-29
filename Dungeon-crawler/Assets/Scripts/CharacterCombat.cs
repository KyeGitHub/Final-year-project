using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Triggered when a character interacts with another character


[RequireComponent(typeof(CharacterStats))] //make sure we actually have stats


public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f; //interval between attacks
    private float attackCooldown = 0f; //timer till next attack
    const float combatCooldown = 5f; //timer for in combat
    float lastAttackTime;

    public float attackDelay = .6f;

    public bool InCombat { get; private set; }
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

        if (Time.time - lastAttackTime > combatCooldown)
        {
            InCombat = false;
        }
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
            InCombat = true; //in combat now
            lastAttackTime = Time.time;//the time we got into combat
        }
   
    }

    IEnumerator DoDamage (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        //damage the target based on the damage value of the attacking character
        stats.TakeDamage(myStats.damage.GetValue());

        if (stats.currentHealth <= 0)
        {
            InCombat = false; //if we killed the target we aren't in combat
        }
    }
}
