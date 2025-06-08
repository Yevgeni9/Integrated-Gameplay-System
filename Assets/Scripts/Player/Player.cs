using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Main, IMoveable
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

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

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }
}
