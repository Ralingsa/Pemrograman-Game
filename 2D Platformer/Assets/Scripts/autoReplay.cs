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
        if (enemyCtrl.enemykilled == 3)
        {
            info.text = "CONGRATULATION\nYOU WIN";
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            //Data.score = 0;
            SceneManager.LoadScene("gameplay1");
        }
    }
}
