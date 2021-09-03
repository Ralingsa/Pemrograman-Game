using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    AudioSource audio;
    public AudioClip hitSound;

    int scoreP1;
    Text scoreUIP1;
    int scoreP2;
    Text scoreUIP2;

    GameObject panelSelesai;
    Text txPemenang;

    void tampilkanScore()
    {
        Debug.Log("Score P1: " + scoreP1 + " Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
    }

    void resetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        scoreP1 = 0;
        scoreP2 = 0;
        scoreUIP1 = GameObject.Find("score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("score2").GetComponent<Text>();

        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);

        panelSelesai = GameObject.Find("panelSelesai");
        panelSelesai.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "pemukul1" || coll.gameObject.name == "pemukul2")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
            audio.PlayOneShot(hitSound);
        }
        if (coll.gameObject.name == "tepiKanan")
        {
            resetBall();
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);

            scoreP1 += 1;
            tampilkanScore();
            if (scoreP1 == 5)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("pemenang").GetComponent<Text>();
                txPemenang.text = "Player Biru Menang";
                Destroy(gameObject);
                return;
            }
        }
        if (coll.gameObject.name == "tepiKiri")
        {
            resetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);

            scoreP2 += 1;
            tampilkanScore();
            if (scoreP2 == 5)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("pemenang").GetComponent<Text>();
                txPemenang.text = "Player Hijau Menang";
                Destroy(gameObject);
                return;
            }
        }
    }
}
