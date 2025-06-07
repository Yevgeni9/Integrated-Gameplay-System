using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Main, IMoveable
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private MovementStateManager movementStateManager;
    
    void Start()
    {
        movementStateManager = new MovementStateManager(this);
        movementStateManager.Start();
    }

    private void Update()
    {
        movementStateManager.Update();
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

    }
}
