using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : CharacterStats
{
   
    [SerializeField]
    GameObject exit;
    public override void Die()
    {
        //call die function
        base.Die();
        GameObject instance = Instantiate(exit, gameObject.transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }
}
