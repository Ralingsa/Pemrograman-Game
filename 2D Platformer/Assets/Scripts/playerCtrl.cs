using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCtrl : MonoBehaviour
{
    bool isJump = true;
    bool isDead = false;
    int idMove = 0;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("jump " + isJump);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Debug.Log("worked");
            moveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Debug.Log("worked");
            moveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            idle();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            idle();
        }
        move();
        dead();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isJump)
        {
            anim.ResetTrigger("jump");
            if (idMove == 0) anim.SetTrigger("idle");
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetTrigger("jump");
        anim.ResetTrigger("run");
        anim.ResetTrigger("idle");
        isJump = true;
    }

    public void moveLeft()
    {
        idMove = 2;
        if (!isJump) anim.SetTrigger("run");
    }

    public void moveRight()
    {
        idMove = 1;
        if (!isJump) anim.SetTrigger("run");
    }



    private void move()
    {
        if (idMove == 1 && !isDead)
        {
            //if (!isJump) anim.SetTrigger("run");
            transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            //Debug.Log("worked");
        }
        if (idMove == 2 && !isDead)
        {
            //if (!isJump) anim.SetTrigger("run");
            transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //Debug.Log("worked");
        }
    }

    public void jump()
    {
        if (!isJump)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 280f);
        }
    }

    public void idle()
    {
        if (!isJump)
        {
            anim.SetTrigger("idle");
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
        }
        idMove = 0;
    }

    private void dead()
    {
        if (!isDead)
        {
            if (transform.position.y < -10f)
            {
                isDead = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("coin"))
        {
            //data.score += 15;
            Destroy(collision.gameObject);
        }
    }
}
