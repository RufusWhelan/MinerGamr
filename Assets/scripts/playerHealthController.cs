using UnityEngine;

public class playerHealthController : MonoBehaviour
{
    public AiControllerScript Ai;
    public camScript camScript;

    [System.Serializable]
    public class PlayerHealth
    {
        public float health;
        public bool isAlive;
        public PlayerHealth(float hp, bool alive)
        {
            health = hp;
            isAlive = alive;
        }
        public void takeDamage()
        {
            health = health - 1f;
            if (health == 0)
                playerDeath();
        }

        public void playerDeath()
        {
            isAlive = false;
        }
    }
    public PlayerHealth player = new PlayerHealth(3, true);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Ai.enemyInstance.damage == true)
        {
            player.takeDamage();
            Ai.enemyInstance.damage = false;
        }
        HandleDeath();
    }

    private void HandleDeath()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (player.isAlive == false)
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                camScript.enabled = false;
                Debug.Log("Player Died");
            }
            
    }
}
