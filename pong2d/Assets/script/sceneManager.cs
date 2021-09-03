﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public bool isEscapeToExit;

    public void mulaiPermainan()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void kemabaliKeMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                kemabaliKeMenu();
            }
        }
    }
}
