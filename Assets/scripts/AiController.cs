using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AiControllerScript : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private Rigidbody aiBody;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float patrolRange = 10f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float viewRange = 15f;
    [SerializeField] private float meleeRange = 2f;
    [SerializeField] private float knockbackForce = 10f;

    public Ai enemy;

    private void Awake()
    {
        playerTarget = GameObject.Find("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();

        enemy = new Ai(navAgent, playerTarget, aiBody, transform, groundLayer, targetLayer,patrolRange, attackCooldown, viewRange, meleeRange, knockbackForce, () => StartCoroutine(ResetAttackCooldown(attackCooldown)));
    }

    private void FixedUpdate()
    {
        enemy.Tick();
    }

    public void triggerDeath()
    {
        StartCoroutine(enemy.Die());
    }

    private IEnumerator ResetAttackCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        enemy.ResetAttack();
    }
}

[System.Serializable]
public class Ai
{
    private NavMeshAgent agent;
    private Transform player;
    private Rigidbody rigidbody;
    private Transform self;
    private LayerMask groundMask;
    private LayerMask playerMask;
    private float patrolRadius;
    private float attackDelay;
    private float visionRange;
    private float hitRange;
    private float recoilForce;

    private Vector3 patrolTarget;
    private bool hasPatrolTarget;
    private bool hasAttacked;
    private bool canSeePlayer;
    private bool canHitPlayer;

    private System.Action onAttackReset;

    public Ai(NavMeshAgent agent, Transform player, Rigidbody rigidbody, Transform self, LayerMask groundMask, LayerMask playerMask, float patrolRadius, float attackDelay, float visionRange, float hitRange, float recoilForce, System.Action onAttackReset
    )
    {
        this.agent = agent;
        this.player = player;
        this.rigidbody = rigidbody;
        this.self = self;
        this.groundMask = groundMask;
        this.playerMask = playerMask;
        this.patrolRadius = patrolRadius;
        this.attackDelay = attackDelay;
        this.visionRange = visionRange;
        this.hitRange = hitRange;
        this.recoilForce = recoilForce;
        this.onAttackReset = onAttackReset;
    }

    public void Tick()
    {
        if (!agent.enabled)
            return;

        canSeePlayer = Physics.CheckSphere(self.position, visionRange, playerMask);
        canHitPlayer = Physics.CheckSphere(self.position, hitRange, playerMask);

        if (!canSeePlayer && !canHitPlayer) Patrol();
        else if (canSeePlayer && !canHitPlayer) Chase();
        else if (canSeePlayer && canHitPlayer) Attack();
    }

    private void Patrol()
    {
        if (!hasPatrolTarget) PickNewPatrolPoint();

        if (hasPatrolTarget)
            agent.SetDestination(patrolTarget);

        if (Vector3.Distance(self.position, patrolTarget) < 1f)
            hasPatrolTarget = false;
    }

    private void PickNewPatrolPoint()
    {
        float randX = Random.Range(-patrolRadius, patrolRadius);
        float randZ = Random.Range(-patrolRadius, patrolRadius);
        Vector3 point = new Vector3(self.position.x + randX, self.position.y, self.position.z + randZ);

        if (Physics.Raycast(point, -Vector3.up, 2f, groundMask))
        {
            patrolTarget = point;
            hasPatrolTarget = true;
        }
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        self.LookAt(player);

        if (!hasAttacked)
        {
            hasAttacked = true;

            var healthController = player.GetComponent<playerHealthController>();
            if (healthController != null && healthController.player.isAlive)
            {
                agent.enabled = false;
                rigidbody.isKinematic = false;
                rigidbody.AddForce(-self.forward * recoilForce, ForceMode.Impulse);

                healthController.player.takeDamage();
                healthController.player.playerDeath();
            }

            onAttackReset?.Invoke();
        }
    }

    public void ResetAttack()
    {
        agent.Warp(self.position);
        hasAttacked = false;
        rigidbody.linearVelocity = Vector3.zero;
        agent.enabled = true;
        rigidbody.isKinematic = true;
    }

    public IEnumerator Die()
    {
        Object.Destroy(agent);
        yield return new WaitForSeconds(0.7f);
        Object.Destroy(self.gameObject);
    }
}