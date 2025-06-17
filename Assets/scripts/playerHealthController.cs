using System.Data.Common;
using UnityEditor.Rendering;
using UnityEngine;

public class playerHealthController : MonoBehaviour
{
    public PlayerHealth player { get; private set; } = new PlayerHealth(3, true); // creates an instance of the class as a monobehavior (I know this looks stupid but its the easiest way to reference an instance of a class in multiple different files)

}

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
        health -= 1f;
    }

    public void playerDeath()
    {
        if (health <= 0)
        {
            isAlive = false;
            Debug.Log("Player Died");
            Time.timeScale = 0f;
        }
    }
}