using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startSpawning()
    {
        yield return new WaitForSeconds(Random.Range(7f,10f));
        Instantiate(enemy, transform.position, Quaternion.identity);
        StartCoroutine(startSpawning());
    }
}
