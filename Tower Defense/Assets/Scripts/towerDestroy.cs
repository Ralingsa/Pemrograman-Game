using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerDestroy : MonoBehaviour
{
    public bool isPlayer = true;
    
    private void OnDestroy()
    {
        if(!Data.isGameOver)
            if (isPlayer)
            {
                Data.isGameOver = true;
                Data.isComplete = false;
                Debug.Log("player lost");
            }
            else
            {
                Data.isGameOver = true;
                Data.isComplete = true;
                Debug.Log("player win");
            }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
