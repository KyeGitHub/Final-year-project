using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    Transform target;
    Transform player;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GetComponent<Transform>();
    }

    private void Update()
    {
        if (target != null)
        {
            if (!target.GetComponent<Enemy>())
            {
                Vector3 source = target.position - (target.position - player.position).normalized * 4;
                NavMeshHit hit;
                if (NavMesh.Raycast(source, target.position, out hit, -1))
                {
                    agent.SetDestination(hit.position);
                }
                else
                {
                    agent.SetDestination(target.position);
                }
            }
            else if (target.GetComponent<Enemy>() & !target.GetComponent<Interactable>().hasInteracted)
            {
                agent.SetDestination(target.position);
            }


            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.updateRotation = false;
        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }
}
