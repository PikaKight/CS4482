using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public InputAction moveAction;
    public int maxHealth;
    public float timeInvincible;

    Rigidbody2D rb;
    Vector2 move;
    bool isInvincible;
    float damageCooldown;

    public int health { get{ return currentHealth; }}

    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        moveAction.Enable();

        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        move = moveAction.ReadValue<Vector2>();

        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown <= 0)
            {
                isInvincible = false;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rb.position + (move * speed * Time.deltaTime);

        rb.MovePosition(position);
    }

    public void changeHealth(int health)
    {
        if (health < 0)
        {
            if (isInvincible)
            {
                return;
            }

            isInvincible = true;
            damageCooldown = timeInvincible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + health, 0, maxHealth);
        UIhandler.instance.SetHealthValue(currentHealth / (float)maxHealth);
    }

    

}
