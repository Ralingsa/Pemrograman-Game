using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCamera : MonoBehaviour
{
    public int cameraMode;
    public GameObject fps, tps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("camera"))
        {
            if (cameraMode == 1)
            {
                cameraMode = 0;
            }
            cameraMode += 1;
        }
        StartCoroutine(switchCamera());
    }

    IEnumerator switchCamera()
    {
        yield return new WaitForSeconds(0.01f);
        if (cameraMode == 0)
        {
            fps.SetActive(true);
            tps.SetActive(false);
        }
        if (cameraMode == 1)
        {
            fps.SetActive(false);
            tps.SetActive(true);
        }
    }
}
