using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float velocity;
    public float topBorder;
    public float bottomBorder;

    public string axis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(axis) * velocity * Time.deltaTime;
        float nextPos = transform.position.y + move;
        if (nextPos > topBorder)
        {
            move = 0;
        }
        if (nextPos < bottomBorder)
        {
            move = 0;
        }
        transform.Translate(0, move, 0);
    }
}
