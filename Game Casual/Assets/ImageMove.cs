using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMove : MonoBehaviour
{
    int[] posX = new int[] { 0, -18, -36, -54 };
    int idx = 0;

    public AudioSource[] audios;

    // Start is called before the first frame update
    void Start()
    {
        audios[idx].Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (idx < posX.Length -1)
            {
                idx++;
                audios[idx].Play();
                Debug.Log("ke kanan");
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (idx > 0)
            {
                idx--;
                audios[idx].Play();
                Debug.Log("ke kiri");
            }
        }
        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(posX[idx], transform.position.y), 50 * Time.deltaTime);
    }
}
