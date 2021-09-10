using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deteksiSampah : MonoBehaviour
{
    public string nameTag;
    public AudioClip audioBenar;
    public AudioClip audioSalah;
    private AudioSource mediaPlayerBenar;
    private AudioSource mediaPlayerSalah;
    public Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        mediaPlayerBenar = gameObject.AddComponent<AudioSource>();
        mediaPlayerBenar.clip = audioBenar;

        mediaPlayerSalah = gameObject.AddComponent<AudioSource>();
        mediaPlayerSalah.clip = audioSalah;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(nameTag))
        {
            data.score += 25;
            textScore.text = data.score.ToString();
            Destroy(collision.gameObject);
            mediaPlayerBenar.Play();
        }
        else
        {
            data.score -= 5;
            textScore.text = data.score.ToString();
            Destroy(collision.gameObject);
            mediaPlayerSalah.Play();
        }
    }
}
