using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class latihan6 : MonoBehaviour
{
    public int[] intArray; //deklarasi array

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("menampilkan seluruh array");
        foreach (int a in intArray)
        {
            Debug.Log(a);
        }
        Debug.Log("nilai indek ke 2 adalah " + intArray[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
