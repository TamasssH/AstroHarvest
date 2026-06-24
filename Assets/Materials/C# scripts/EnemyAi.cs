using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float patrolRadius = 15f;
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public int attackDamage = 15;
    public float attackRate = 1.5f;

    public Transform player;
    private NavMeshAgent agent;
    private bool isChasing = false;
    private float nextAttackTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GotoRandomPoint();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= attackRange && Time.time >= nextAttackTime)
        {
            AttackPlayer();
            nextAttackTime = Time.time + attackRate;
        }
        else if (dist <= chaseRange)
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

    void AttackPlayer()
    {
        Health pHealth = player.GetComponent<Health>();
        if (pHealth != null) pHealth.TakeDamage(attackDamage);
    }

    void GotoRandomPoint()
    { /* same as before */
        Vector3 randomPos = Random.insideUnitSphere * patrolRadius + transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPos, out hit, patrolRadius, NavMesh.AllAreas))
            agent.destination = hit.position;
    }
}