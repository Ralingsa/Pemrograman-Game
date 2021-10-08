using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defender : MonoBehaviour
{
    public bool isPlayer = true;
    private bool isDefend = false;
    public int defense = 300;

    [HideInInspector]
    public int underAttack;
    private float timer;
    private string nameTagLawan;

    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
        {
            nameTagLawan = "enemy";
        }
        else
        {
            nameTagLawan = "Player";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDefend)
        {
            //attack
            timer += Time.deltaTime;
            if (timer > 0.6f)
            {
                defense -= underAttack;
                timer = 0;
            }
        }
        if (defense <= 0)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 9 || transform.position.x < -9)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals(nameTagLawan))
        {
            isDefend = true;
            
            attacker m = collision.gameObject.GetComponent<attacker>();
            if (m != null) m.underAttack = 0;

            defender d = collision.gameObject.GetComponent<defender>();
            if (d != null) d.underAttack = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isDefend = false;
    }
}
