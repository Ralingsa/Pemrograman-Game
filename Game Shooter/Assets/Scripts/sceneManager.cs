using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void menuScene()
    {
        SceneManager.LoadScene("menu");
        Debug.Log("ke menu");
    }

    public void mainScene()
    {
        SceneManager.LoadScene("main");
        Debug.Log("Mulai permainan");
    }

    public void quitScene()
    {
        Application.Quit();
        Debug.Log("keluar");
    }
}
