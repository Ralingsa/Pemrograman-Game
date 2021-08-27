using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public string EnterScene;
    public string EscapeScene;
        public bool isEscapeForQuit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Debug.Log("Name Scene : " + EnterScene);
            UnityEngine.SceneManagement.SceneManager.LoadScene(EnterScene);
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Name Scene : " + EscapeScene);
            UnityEngine.SceneManagement.SceneManager.LoadScene(EscapeScene);
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeForQuit)
            {
                Application.Quit();
            }
            else
            {
                Debug.Log("Name Scene : " + EscapeScene);
                UnityEngine.SceneManagement.SceneManager.LoadScene(EscapeScene);
            }
        }
    }
}
