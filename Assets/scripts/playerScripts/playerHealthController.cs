using UnityEngine;
using UnityEngine.SceneManagement;
public class playerHealthController : MonoBehaviour
{
    public PlayerHealth player { get; private set; } = new PlayerHealth(3, true); // creates a player health instance that can be shared and accessed easily
}

[System.Serializable]
public class PlayerHealth
{
    [SerializeField] private float health;
    [SerializeField] public bool isAlive;

    public PlayerHealth(float hp, bool alive)
    {
        health = hp;
        isAlive = alive;
    }

    public void takeDamage()
    {
        /*
        Reduces the players health by one

        'Returns':
            float: players current health
        */
        health -= 1f; // subtracts 1 health when hit
    }

    public void playerDeath()
    {
        /*
            Checks if the player is alive and freezes time if they are not

            'Returns':
            bool : if the player is alive
        */
        if (health <= 0)
        {
            isAlive = false; // mark player as dead
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("Player Died");
            SceneManager.LoadScene(3);
        }
    }
}