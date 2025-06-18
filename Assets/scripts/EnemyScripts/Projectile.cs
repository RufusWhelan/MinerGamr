using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime); // destroys the projectile after a short delay
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        Checks if the projectile hit the player, and applies damage if it did.
        Args:
            collision (collision): the collider of what the projectile hit

        'Returns':
`             a destroyed projectile
        */
        if (collision.gameObject.CompareTag("Player"))
        {
            var healthController = collision.gameObject.GetComponent<playerHealthController>();
            if (healthController != null && healthController.player.isAlive)
            {
                healthController.player.takeDamage();
                healthController.player.playerDeath();
            } //on collision with player, deal damage to the player then check if they are dead.
        }

        Destroy(gameObject); // Destroy projectile after any collision
    }
}