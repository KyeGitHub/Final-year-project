using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        //call die function
        base.Die();

        //add whatever death thing

        Destroy(gameObject);
    }
}
