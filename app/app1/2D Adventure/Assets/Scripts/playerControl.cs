using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public Vector2 jumpHeight;

    public InputAction moveAction;
    public InputAction jumpAction;

    public Rigidbody2D rb;

    private bool onGround = true;

    // Start is called before the first frame update
    void Start()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector2 position = (Vector2)transform.position + (move * speed * Time.deltaTime);

        transform.position = position;

        if (jumpAction.IsPressed() && onGround)
        {
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
            onGround = false;
        }

  }
}
