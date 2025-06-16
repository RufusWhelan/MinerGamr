using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AiControllerScript : MonoBehaviour
{
    public AiController enemyInstance;
    public GameObject itself;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundMask, playerMask;

    [System.Serializable]
    public class AiController
    {
        private GameObject owner;
        private NavMeshAgent pathFinder;
        private Transform playerPos;
        private LayerMask groundLayer, playerLayer;
        public Vector3 walkPoint;
        private bool walkPointSet;
        private float walkPointRange;
        public float fieldOfView, damageRange;
        [HideInInspector] public bool playerSeen, playerInDamageRange, damage, attacked;
        public float timeBetweenAttacks;

        public AiController(GameObject ownerObj, NavMeshAgent finder, Transform pos, LayerMask ground, LayerMask player, Vector3 point, bool pointSet, float pointRge, float FOV, float damRge, bool seen, bool inDamRge, bool dam, bool atkd, float btwAtk)
        {
            owner = ownerObj;
            pathFinder = finder;
            playerPos = pos;
            groundLayer = ground;
            playerLayer = player;
            walkPoint = point;
            walkPointSet = pointSet;
            pathFinder = finder;
            walkPointRange = pointRge;
            fieldOfView = FOV;
            damageRange = damRge;
            playerSeen = seen;
            playerInDamageRange = inDamRge;
            damage = dam;
            attacked = atkd;
            timeBetweenAttacks = btwAtk;
        }

        public void SearchWalkpoint()
        {
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);
            walkPoint = new Vector3(owner.transform.position.x + randomX, owner.transform.position.y, owner.transform.position.z + randomZ);

            if (Physics.Raycast(walkPoint, -owner.transform.up, 2f, groundLayer))
                walkPointSet = true;
        }

        public void Patrolling()
        {
            if (!walkPointSet) SearchWalkpoint();

            if (walkPointSet)
                pathFinder.SetDestination(walkPoint);

            Vector3 distanceToWalkpoint = owner.transform.position - walkPoint;

            if (distanceToWalkpoint.magnitude < 1f)
                walkPointSet = false;

        }

        public void Chase()
        {
            pathFinder.SetDestination(playerPos.position);
        }
        public void Attack(System.Action resetAttackCallback)
        {
            owner.transform.LookAt(playerPos);
            if (!attacked)
            {
                attacked = true;
                damage = true;
                resetAttackCallback?.Invoke();
            }
        }

        private void ResetAttack()
        {
            attacked = false;
        }

    }


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        enemyInstance = new AiController(gameObject, agent, player, groundMask, playerMask, new Vector3(0, 0, 0), false, 0f, 0f, 0f, false, false, false, false, 1f);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        enemyInstance.playerSeen = Physics.CheckSphere(transform.position, enemyInstance.fieldOfView, playerMask);
        enemyInstance.playerInDamageRange = Physics.CheckSphere(transform.position, enemyInstance.damageRange, playerMask);

        if (!enemyInstance.playerSeen && !enemyInstance.playerInDamageRange) enemyInstance.Patrolling();

        if (enemyInstance.playerSeen && !enemyInstance.playerInDamageRange) enemyInstance.Chase();

        if (enemyInstance.playerSeen && enemyInstance.playerInDamageRange)
        enemyInstance.Attack(() => StartCoroutine(ResetAttackCoroutine(enemyInstance.timeBetweenAttacks)));
    }

    public void triggerDeath()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
    private IEnumerator ResetAttackCoroutine(float delay)
{
    yield return new WaitForSeconds(delay);
    enemyInstance.attacked = false;
}
}
