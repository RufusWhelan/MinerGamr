using UnityEngine;

public class endPoint : MonoBehaviour
{
        public GameObject player;
    public UIController UIController; //Inisialises a script from a different gameobject
    private void OnCollisionEnter(Collision other) //Checks collisions it has with other objects
    {
        /*
            On collision with player, trigger the end screen

            'Returns':
            the end scene
        */
        if (other.gameObject.CompareTag("Player"))
            UIController.gameStart();
            //if the tag of a game object is "Player" use the method gameStart() from gameOverScreenScript.
    }
}
