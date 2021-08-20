using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prajurit : manusia
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("seorang prajurit dapat: ");
        makan();
        tidur();
        menyerang();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void menyerang()
        {
            Debug.Log("menyerang");
        }
}
