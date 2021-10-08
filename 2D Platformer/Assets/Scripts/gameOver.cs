using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public Text txScore;
    public Text txHighScore;
    Text selamat;
    int highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HS", 0);

        if (Data.data.score > highScore)
        {
            highScore = Data.data.score;
            PlayerPrefs.SetInt("HS", highScore);
        }
        else if (enemyCtrl.enemykilled == 3)
        {
           SceneManager.LoadScene("congratulation");
        }

        txHighScore.text = "HIGH SCORE: " + highScore;
        txScore.text = "SCORE: " + Data.data.score;
    }

    public void replay()
    {
        Data.data.score = 0;
        enemyCtrl.enemykilled = 0;
        SceneManager.LoadScene("gameplay1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
