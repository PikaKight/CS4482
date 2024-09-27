using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float maxMoveTime;
    public bool verticle;
    public int damage;
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


        if (verticle) {
            position.y = position.y + speed * Time.deltaTime;
            
        }

        else
        {
            position.x = position.x + speed * Time.deltaTime;
        
        }

        rb.MovePosition(position);

        moveTime -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null) {
            player.changeHealth(damage);
        }
    }
}
