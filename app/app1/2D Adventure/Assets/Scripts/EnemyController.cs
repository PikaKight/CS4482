using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float maxMoveTime;
    public bool verticle;
    public bool random;
    public int damage;
    Rigidbody2D rb;

    float moveTime;
    float wait = 5; 
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

        if (random && (wait < 0)) {
            verticle = ! verticle;
            wait = 5;
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
        wait -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        Debug.Log(player);

        if (player != null) {
            Debug.Log("Hi");
            player.changeHealth(damage*-1);
        }
    }
}
