using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player
{
    public MovementStateManager movementStateManager;
    private AttackStateManager attackStateManager;
    public InputManager inputManager;
    public GameSettingsConfig gameConfig;
    public Player enemy; // The opposing player
    public HealthSystem healthSystem;

    public Transform transform;
    public Rigidbody2D rb;
    public Collider2D bodyCollider;
    public GameObject punchHitbox;
    public GameObject kickHitbox;
    public GameObject slashHitbox;

    public event Action OnHit;
    public string playerName;

    public Player(InputConfig inputConfig, Rigidbody2D rb, Transform transform, GameObject punch, GameObject kick, GameObject slash, HealthSystem healthSystem, GameSettingsConfig gameConfig, string playerName, MonoBehaviour coroutineStarter)
    {
        this.rb = rb;
        this.transform = transform;
        this.punchHitbox = punch;
        this.kickHitbox = kick;
        this.slashHitbox = slash;
        this.healthSystem = healthSystem;
        this.gameConfig = gameConfig;
        this.playerName = playerName;

        movementStateManager = new MovementStateManager(transform, gameConfig, this);
        attackStateManager = new AttackStateManager(this, gameConfig, coroutineStarter);
        inputManager = new InputManager(inputConfig);

        attackStateManager.OnAttackStart += () => movementStateManager.SetAllowInput(false);
        attackStateManager.OnAttackEnd += () => movementStateManager.SetAllowInput(true);
    }

    public void Update()
    {
        movementStateManager.Update();
        attackStateManager.Update();
        inputManager.ManageMovementInputs(movementStateManager);
        inputManager.ManageAttackInputs(attackStateManager);
        FaceTarget(enemy);
    }

    // To face the right direction I am flipping the scale to -1, when using assets a sprite flip can be done
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

    public void CheckIfGrounded(LayerMask groundLayer)
    {
        bool isGrounded = bodyCollider.IsTouchingLayers(groundLayer);
        movementStateManager.SetGrounded(isGrounded);
    }

    public void TakeDamage(int amount)
    {
        healthSystem.TakeDamage(amount);
        OnHit?.Invoke();
    }
}
