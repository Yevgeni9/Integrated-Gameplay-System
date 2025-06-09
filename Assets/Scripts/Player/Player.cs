using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Main, IMoveable
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private bool isGrounded;

    private MovementStateManager movementStateManager;
    private InputManager inputManager;

    private Rigidbody2D rb;
    
    void Start()
    {
        movementStateManager = new MovementStateManager(this);
        movementStateManager.Start();
        inputManager = new InputManager();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movementStateManager.Update();
        inputManager.ManageInput(movementStateManager);
    }

    public void GoLeft()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    public void GoRight()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    public void StartCrouching()
    {
        transform.localScale = new Vector2(1, 1); // Ideally I would change a sprite here or start an animation, but for the prototype im just reducing the cube size
    }

    public void StopCrouching()
    {
        transform.localScale = new Vector2(1, 2); // Reset to normal size
    }

    public void Dash()
    {

    }

    public void Jump()
    {
        if (!isGrounded)
        {
            return;
        }

        rb.AddForce(Vector2.up * jumpForce);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
