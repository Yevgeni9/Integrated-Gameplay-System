using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager
{
    public Player player;
    MovementBaseState currentState;

    public readonly Transform transform;
    public readonly float moveSpeed;
    public readonly float jumpForce;
    public bool isGrounded;
    public bool AllowInput { get; private set; } = true;

    public IdleState idleState = new IdleState();
    public LeftState leftState = new LeftState();
    public RightState rightState = new RightState();
    public CrouchState crouchState = new CrouchState();
    public JumpState jumpState = new JumpState();
    public DashState dashState = new DashState();
    public HitState hitState = new HitState();

    public MovementStateManager(Transform playerTransform, float moveSpeed, float jumpForce, Player player)
    {
        Start();
        this.transform = playerTransform;
        this.moveSpeed = moveSpeed;
        this.player = player;
        this.jumpForce = jumpForce;

        player.OnHit += EnterHitState;
    }

    public void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    public void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(MovementBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }

    public void SetGrounded(bool grounded)
    {
        isGrounded = grounded;
    }

    public void SetAllowInput(bool allowed)
    {
        AllowInput = allowed;
    }

    private void EnterHitState()
    {
        SwitchState(hitState);
    }

    public Rigidbody2D GetRb() => player.rb;
}
