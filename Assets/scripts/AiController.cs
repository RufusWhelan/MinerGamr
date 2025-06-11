using System;
using UnityEngine;
using UnityEngine.AI;

public class AiControllerScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundLayer, playerLayer;
    public class AiController
    {
        public Vector3 walkPoint;
        public bool walkPointSet;
        public float walkPointRange;
        public float fieldOfView, damageRange;
        public bool playerSeen, playerInDamageRange;
        public AiController(Vector3 point, bool pointSet, float pointRge, float FOV, float damRge, bool seen, bool inDamRge)
        {
            walkPoint = point;
            walkPointSet = pointSet;
            walkPointRange = pointRge;
            fieldOfView = FOV;
            damageRange = damRge;
            playerSeen = seen;
            playerInDamageRange = inDamRge;

        }

        public void Patrolling()
        {
            
        }
        
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
