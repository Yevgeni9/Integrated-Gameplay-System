using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player
{
    public MovementStateManager movementStateManager;
    private AttackStateManager attackStateManager;
    public InputManager inputManager; // Public because DashState Needs it
    
    public Transform transform;
    public Rigidbody2D rb;
    public Collider2D bodyCollider;
    public GameObject punchHitbox;
    public GameObject kickHitbox;
    public GameObject slashHitbox;

    public Player enemy; // The opposing player
    public HealthSystem healthSystem;

    public event Action OnHit;

    public Player(InputConfig inputConfig, Rigidbody2D rb, Transform transform, GameObject punch, GameObject kick, GameObject slash, HealthSystem healthSystem, MonoBehaviour coroutineStarter)
    {
        this.rb = rb;
        this.transform = transform;
        this.punchHitbox = punch;
        this.kickHitbox = kick;
        this.slashHitbox = slash;
        this.healthSystem = healthSystem;

        movementStateManager = new MovementStateManager(transform, 5f, 1500f, this);
        attackStateManager = new AttackStateManager(this, coroutineStarter);
        inputManager = new InputManager(inputConfig);
    }

    public void Update()
    {
        movementStateManager.Update();
        attackStateManager.Update();
        inputManager.ManageMovementInputs(movementStateManager);
        inputManager.ManageAttackInputs(attackStateManager);
        FaceTarget(enemy);
    }

    public void FaceTarget(Player otherPlayer)
    {
        if (movementStateManager.isGrounded && attackStateManager.currentState == attackStateManager.noAttackState)
        {
            float direction = otherPlayer.transform.position.x - this.transform.position.x;

            Vector3 localScale = transform.localScale;
            localScale.x = direction >= 0 ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
            transform.localScale = localScale;
        }
    }

    public void SetGrounded(bool grounded)
    {
        movementStateManager.SetGrounded(grounded);
    }

    public void TakeDamage(int amount)
    {
        healthSystem.TakeDamage(amount);
        OnHit?.Invoke();
    }
}
