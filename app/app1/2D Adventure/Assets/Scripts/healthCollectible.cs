using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCollectible : MonoBehaviour
{
    public int health;


    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null && controller.health < controller.maxHealth)
        {

            controller.changeHealth(health);
            Destroy(gameObject);
        }   
    }
}
