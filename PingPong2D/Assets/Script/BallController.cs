using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    int scoreP1;
    int scoreP2;

    Rigidbody2D rigid;

    GameObject panelSelesai;

    Text scoreUIP1;
    Text scoreUIP2;
    Text txPemenang;

    AudioSource audio;
    public AudioClip hitSound;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(2, 0).normalized;
        rigid.AddForce(direction * force);
        scoreP1 = 0;
        scoreP2 = 0;
        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();
        panelSelesai = GameObject.Find("GameOverPanel");
        panelSelesai.SetActive(false);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.PlayOneShot(hitSound);
        if(collision.gameObject.name == "TepiKanan")
        {
            scoreP1 += 1;
            ShowScore();
            ResetBall();
            Vector2 direction = new Vector2(-2, 0).normalized;
            rigid.AddForce(direction * force);
            if(scoreP1 == 5)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Winner").GetComponent<Text>();
                txPemenang.text = "Player 1 Win";
                Destroy(gameObject);
                return;
            }
        }
        if (collision.gameObject.name == "TepiKiri")
        {
            scoreP2 += 1;
            ShowScore();
            ResetBall();
            Vector2 direction = new Vector2(2, 0).normalized;
            rigid.AddForce(direction * force);
            if (scoreP2 == 5)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Winner").GetComponent<Text>();
                txPemenang.text = "Player 2 Win";
                Destroy(gameObject);
                return;
            }
        }
        if(collision.gameObject.name == "Paddle1" || collision.gameObject.name == "Paddle2")
        {
            float angel = (transform.position.y - collision.transform.position.y) * 5f;
            Vector2 direction = new Vector2(rigid.velocity.x, angel).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(direction * force * 2);
        }
    }

    void ShowScore()
    {
        Debug.Log("Score P1: " + scoreP1 + " Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
    }
}
