using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacker : MonoBehaviour
{
    public bool isPlayer = true;
    private bool isMove = true;
    public int atk = 100, def = 200;

    [HideInInspector]
    public int underAttack;
    public float timer = 0, posYLawan;
    private bool isCari = false;
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
        if (isPlayer)
        {
            if (isMove)
            {
                transform.position += transform.right * Time.deltaTime * 0.5f;
                if (transform.position.y > (posYLawan + 0.1f) && isCari)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y - Time.deltaTime));
                }
                if (transform.position.y < (posYLawan + 0.1f) && isCari)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y + Time.deltaTime));
                }
            }
            else
            {
                //attack
                timer += Time.deltaTime;
                if (timer > 0.6f)
                {
                    def -= underAttack;
                    transform.localScale = new Vector3(1, 1f);
                    timer = 0;
                }
                else if (timer > 0.5f)
                {
                    transform.localScale = new Vector3(1, 1.2f);
                }
            }
        }
        else
        {
            if (isMove)
            {
                transform.position -= transform.right * Time.deltaTime * 0.05f;
                if (transform.position.y > (posYLawan + 0.1f) && isCari)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y - Time.deltaTime));
                }
                if (transform.position.y < (posYLawan + 0.1f) && isCari)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y + Time.deltaTime));
                }

            }
            else
            {
                //attack
                timer += Time.deltaTime;
                if (timer > 0.6f)
                {
                    def -= underAttack;
                    transform.localScale = new Vector3(1, 1f);
                    timer = 0;
                }
                else if (timer > 0.5f)
                {
                    transform.localScale = new Vector3(1, 1.2f);
                }
            }
        }
        if (def <= 0)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 9 || transform.position.x < -9)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals(nameTagLawan) && isMove)
        {
            isMove = false;

            attacker m = collision.gameObject.GetComponent<attacker>();
            if (m != null) m.underAttack = atk;
            defender d = collision.gameObject.GetComponent<defender>();
            if (d != null) d.underAttack = atk;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals(nameTagLawan))
        {
            isCari = true;
            posYLawan = collision.transform.position.y;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        isMove = true;
        transform.localScale = new Vector3(1, 1f);
    }
}
