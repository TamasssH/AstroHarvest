using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float patrolRadius = 15f;
    public float chaseRange = 10f;
    public Transform player;

    private NavMeshAgent agent;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GotoRandomPoint();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= chaseRange)
        {
            isChasing = true;
            agent.destination = player.position;
        }
        else if (isChasing)
        {
            isChasing = false;
            GotoRandomPoint();
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoRandomPoint();
        }
    }

    void GotoRandomPoint()
    {
        Vector3 randomPos = Random.insideUnitSphere * patrolRadius + transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPos, out hit, patrolRadius, NavMesh.AllAreas))
        {
            agent.destination = hit.position;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, patrolRadius);
        if (agent)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, agent.destination);
        }
    }
}