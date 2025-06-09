using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Main
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpForce;
    public bool isGrounded { get; private set; } = true;

    private MovementStateManager movementStateManager;
    private InputManager inputManager;

    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        movementStateManager = new MovementStateManager(transform, moveSpeed, jumpForce, this);
        movementStateManager.Start();
        inputManager = new InputManager();
    }

    private void Update()
    {
        movementStateManager.Update();
        inputManager.ManageInput(movementStateManager);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            movementStateManager.SetGrounded(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            movementStateManager.SetGrounded(false);
        }
    }
}
