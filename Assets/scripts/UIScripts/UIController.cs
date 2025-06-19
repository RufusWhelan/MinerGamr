using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void gameStart()
    {
        /*
            Moves the player to the new scene

            'Returns':
            the next scene
        */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // loads the next scene
    }

    public void respawn()
    {

        /*
            Moves the player to the prototype scene

            'Returns':
            the next scene
        */
        SceneManager.LoadScene(1); // loads the game scene
    }
    


    public void gameQuit()
    {
        /*
            Closes the application

            'Returns':
            closed game
        */
        Debug.Log("quit");
        Application.Quit(); //closes the application
    }
}
