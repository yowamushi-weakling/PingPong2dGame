using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int force;

    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(2, 0).normalized;
        rigid.AddForce(direction * force);
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
        if(collision.gameObject.name == "TepiKanan")
        {
            ResetBall();
            Vector2 direction = new Vector2(-2, 0).normalized;
            rigid.AddForce(direction * force);
        }
        if (collision.gameObject.name == "TepiKiri")
        {
            ResetBall();
            Vector2 direction = new Vector2(2, 0).normalized;
            rigid.AddForce(direction * force);
        }
        if(collision.gameObject.name == "Paddle1" || collision.gameObject.name == "Paddle2")
        {
            float angel = (transform.position.y - collision.transform.position.y) * 5f;
            Vector2 direction = new Vector2(rigid.velocity.x, angel).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(direction * force * 2);
        }
    }
}
