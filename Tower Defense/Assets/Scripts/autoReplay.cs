using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class autoReplay : MonoBehaviour
{
    float timer = 0;
    public Text info;

    // Start is called before the first frame update
    void Start()
    {
        if (Data.isComplete)
        {
            info.text = "CONGRATULATION\nYOU WIN!";
        }
        else
        {
            info.text = "GAME OVER\nYOU LOSE!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            Data.isGameOver = false;
            Data.isComplete = false;
            Data.coin = 0;
            SceneManager.LoadScene("gameplay");
        }
    }
}
