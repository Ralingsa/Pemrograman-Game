using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyCtrl : MonoBehaviour
{
    public bool isGrounded = false;
    public bool isFacingR = false;
    public bool isDie = false;
    public Transform batas1;
    public Transform batas2;

    Rigidbody2D rigid;
    Animator anim;
    public int HP = 1;
    public static int enemykilled = 0;

    float speed = 2;

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        isFacingR = !isFacingR;
    }

    void moveR()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (!isFacingR)
        {
            flip();
        }
    }

    void moveL()
    {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
        if (isFacingR)
        {
            flip();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && !isDie)
        {
            if (isFacingR)
            {
                moveR();
            }
            else
            {
                moveL();
            }

            if (transform.position.x >= batas2.position.x && isFacingR)
            {
                flip();
                isFacingR = false;
            }
            else if (transform.position.x <= batas1.position.x && !isFacingR)
            {
                flip();
                isFacingR = true;
            }
        }
    }

    void takeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            isDie = true;
            rigid.velocity = Vector2.zero;
            anim.SetBool("isDie", true);
            //data.score += 20;
            enemykilled++;
            if (enemykilled == 3)
            {
                SceneManager.LoadScene("game over");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
