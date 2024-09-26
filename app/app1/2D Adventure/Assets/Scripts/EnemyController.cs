using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float maxMoveTime;
    Rigidbody2D rb;

    float moveTime;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveTime = maxMoveTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rb.position;

        if (moveTime < 0)
        {
            speed *= -1;
            moveTime = maxMoveTime;
        }


        position.x = position.x + speed * Time.deltaTime;
        rb.MovePosition(position);

        moveTime -= Time.deltaTime;
    }
}
