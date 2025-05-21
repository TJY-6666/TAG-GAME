using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{


    public void start()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void howToPlay()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void feedback()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void quit()
    {
        Application.Quit();
    }

}
