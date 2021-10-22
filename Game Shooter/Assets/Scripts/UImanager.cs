using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    public Text ammoText;

    public void resetScore()
    {
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + score;
        ammoText.text = weaponCtrl.ammo + "/" + weaponCtrl.ammoMag;
    }
}
