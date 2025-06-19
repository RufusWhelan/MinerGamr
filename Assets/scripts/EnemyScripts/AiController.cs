using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AiControllerScript : MonoBehaviour
{
    [SerializeField] private bool melee; // used to toggle between melee and ranged enemy
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private Rigidbody aiBody;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float patrolRange = 10f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float viewRange = 15f;
    [SerializeField] private float attackRange;
    [SerializeField] private float knockbackForce = 10f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletForce;

    public Ai enemy; // the current instance of either melee or ranged AI

    private void Awake()
    {
        playerTarget = GameObject.Find("Player").transform; // grabs the player’s transform in the scene
        navAgent = GetComponent<NavMeshAgent>(); // gets reference to AI nav component

        // decides which type of AI to spawn
        if (melee == true)
            enemy = new MeleeEnemy(navAgent, playerTarget, aiBody, transform, groundLayer, targetLayer, patrolRange, attackCooldown, viewRange, attackRange, knockbackForce, () => StartCoroutine(ResetAttackCooldown(attackCooldown)));

        if (melee == false)
            enemy = new RangedEnemy(navAgent, playerTarget, aiBody, transform, groundLayer, targetLayer, patrolRange, attackCooldown, viewRange, attackRange, bullet, bulletForce, () => StartCoroutine(ResetAttackCooldown(attackCooldown)));
    }

    private void FixedUpdate()
    {
        enemy.Tick(); // calls AI logic every physics update
    }

    public void triggerDeath()
    {
        StartCoroutine(enemy.Die()); // starts death coroutine
    }

    private IEnumerator ResetAttackCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        enemy.ResetAttack(); // resets attack state
    }
}

[System.Serializable]
public class Ai
{
    // common AI properties for all enemies
    protected readonly NavMeshAgent agent;
    protected readonly Transform player;
    protected Rigidbody rigidbody;
    protected Transform self;
    protected LayerMask groundMask;
    protected LayerMask playerMask;
    protected float patrolRadius;
    protected float attackDelay;
    protected float visionRange;
    protected float hitRange;

    protected Vector3 patrolTarget;
    protected bool hasPatrolTarget;
    protected bool hasAttacked;
    protected bool canSeePlayer;
    protected bool canHitPlayer;

    protected System.Action onAttackReset; // action to reset attack after delay

    public Ai(NavMeshAgent agent, Transform player, Rigidbody rigidbody, Transform self, LayerMask groundMask, LayerMask playerMask, float patrolRadius, float attackDelay, float visionRange, float hitRange, System.Action onAttackReset)
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
        this.onAttackReset = onAttackReset;
    }

    public void Tick()
    {
        /*
        Swtches between the AI's states and checks if it can see anything everyframe

        'Returns'
        AI state
        */
        if (agent == null || !agent.isOnNavMesh || !agent.enabled)
            return; //if the pathfinder for the enemy does not exist or is diabled, return.

        canSeePlayer = Physics.CheckSphere(self.position, visionRange, playerMask);
        canHitPlayer = Physics.CheckSphere(self.position, hitRange, playerMask);
        // checks if enemy can see or hit the player

        // decision tree
        if (!canSeePlayer && !canHitPlayer) Patrol(); // if player not in sight patrol
        else if (canSeePlayer && !canHitPlayer) Chase(); // if player seen but out of range chase
        else if (canSeePlayer && canHitPlayer) Attack(); // if player seen and in range attack
    }

    private void Patrol()
    {
        /*
        moves the AI between two points

        Returns:
            Vector3: enemy position

        */
        if (!hasPatrolTarget) PickNewPatrolPoint(); //if no patrol points, make some

        if (hasPatrolTarget)
            agent.SetDestination(patrolTarget); //if a patrol point exists, the agent patrols

        if (Vector3.Distance(self.position, patrolTarget) < 1f)
            hasPatrolTarget = false; // if the player is too far away from their patrol points, create a new one
    }

    private void PickNewPatrolPoint()
    {
        /*
        creates a new patrol path for the AI to travel on

        'Returns':
            Vector3: point that the AI will patrol
        */
        float randX = Random.Range(-patrolRadius, patrolRadius);
        float randZ = Random.Range(-patrolRadius, patrolRadius);
        Vector3 point = new Vector3(self.position.x + randX, self.position.y, self.position.z + randZ);
        // creates a random point in range around the enemy

        if (Physics.Raycast(point, -Vector3.up, 2f, groundMask)) // checks that the point is on the ground
        {
            patrolTarget = point;
            hasPatrolTarget = true;
        }
    }

    private void Chase()
    /*
    AI moves towards player position

    Returns:
            Vector3: enemy position
    */
    {
        agent.SetDestination(player.position); // move towards player
    }

    protected virtual void Attack()
    {
        /* 
        AI attacks
        Returns:
            float: players health
        */
    } // overriden by subclasses
    public virtual void ResetAttack()
    {
        /* 
        Resets AI attacks
        Returns:
            bool: if the player has attacked
        */
    } // overriden by subclasses

    public IEnumerator Die()
    {
        if (agent != null)
            Object.Destroy(agent); // disable pathfinding on death

        yield return new WaitForSeconds(0.7f); // short delay for death animation/sound
        Object.Destroy(self.gameObject); // remove from scene
    }
}

public class MeleeEnemy : Ai
{
    private float recoilForce;

    public MeleeEnemy(NavMeshAgent agent, Transform player, Rigidbody rigidbody, Transform self, LayerMask groundMask, LayerMask playerMask, float patrolRadius, float attackDelay, float visionRange, float hitRange, float recoilForce, System.Action onAttackReset) : base(agent, player, rigidbody, self, groundMask, playerMask, patrolRadius, attackDelay, visionRange, hitRange, onAttackReset)
    {
        this.recoilForce = recoilForce;
    }

    protected override void Attack()
    {
        self.LookAt(player); // face player before attacking

        if (!hasAttacked)
        {
            hasAttacked = true;

            var healthController = player.GetComponent<playerHealthController>();
            if (healthController != null && healthController.player.isAlive)
            {
                agent.enabled = false; // stop AI movement
                rigidbody.isKinematic = false;
                rigidbody.AddForce(-self.forward * recoilForce, ForceMode.Impulse); // apply recoil
                healthController.player.takeDamage();
                healthController.player.playerDeath(); // check if the player is dead
            }

            onAttackReset?.Invoke(); // schedule reset
        }
    }

    public override void ResetAttack()
    {
        hasAttacked = false;
        rigidbody.linearVelocity = Vector3.zero; // cancel momentum
        agent.enabled = true;
    }
}

public class RangedEnemy : Ai
{
    private GameObject projectile;
    private float projectileForce;

    public RangedEnemy(NavMeshAgent agent, Transform player, Rigidbody rigidbody, Transform self, LayerMask groundMask, LayerMask playerMask, float patrolRadius, float attackDelay, float visionRange, float hitRange, GameObject projectile, float projectileForce, System.Action onAttackReset) : base(agent, player, rigidbody, self, groundMask, playerMask, patrolRadius, attackDelay, visionRange, hitRange, onAttackReset)
    {
        this.projectile = projectile;
        this.projectileForce = projectileForce;
    }

    protected override void Attack()
    {
        /*
        AI attacks
        Returns:
            gameObject: projectile that is being fired at the player
        */
        agent.SetDestination(agent.transform.position); // stop moving during attack
        self.LookAt(player); // face player

        if (!hasAttacked)
        {
            hasAttacked = true;

            Vector3 spawnPos = self.position + self.forward * 1f;
            Vector3 direction = (player.position - spawnPos).normalized;
            direction += Vector3.up * 0.25f; // add slight upward arc
            direction.Normalize();

            GameObject newBullet = GameObject.Instantiate(projectile, spawnPos, Quaternion.LookRotation(direction));
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();

            rb.AddForce(direction * projectileForce, ForceMode.Impulse); // fire projectile

            onAttackReset?.Invoke(); // reset after cooldown
        }
    }

    public override void ResetAttack()
    {
        hasAttacked = false;
    }
}
