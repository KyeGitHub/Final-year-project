using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Controls the Enemy AI*/

public class EnemyAiController : MonoBehaviour
{
    public float lookRadius = 10f; //Detection range

    Transform target; //Reference to the player
    NavMeshAgent agent; //Reference to nav mesh agent
    CharacterCombat combat; //Reference to combat


    public float wanderRadius;
    public float wanderTimer;
    private float timer;

    void Start()
    {
        //grabbing everything
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        wanderTimer = Random.value * 10;
        wanderRadius = Random.value * 100;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        timer += Time.deltaTime;

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>(); // grab the targets stats

                if (targetStats != null) //if the target has stats and we haven't some how messed up and attacked something that we shouldn't be able to
                {
                    // Attack
                    combat.Attack(targetStats); //attack the targets Stats
                    FaceTarget();
                }

            }
        }
        else if (timer >= wanderTimer)
        {
            Wander();
            wanderTimer = Random.value * 10;
            wanderRadius = Random.value * 100;
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRatation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRatation, Time.deltaTime * 5f);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public void Wander()
    {
        //Debug.Log("Wander");
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
        agent.SetDestination(newPos);
        timer = 0;
    }
}

