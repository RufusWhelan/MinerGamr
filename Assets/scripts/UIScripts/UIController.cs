using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void gameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void gameQuit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void modeSwitchSlider(float value)
    {
        float localvalue = value;
        if (localvalue == 0)
            Debug.Log("switchedToControllerBinds");
    }
}
