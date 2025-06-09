using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : Player
{
    MovementBaseState currentState;
    public IdleState idleState = new IdleState();
    public LeftState leftState = new LeftState();
    public RightState rightState = new RightState();
    public CrouchState crouchState = new CrouchState();
    public JumpState jumpState = new JumpState();
    public DashState dashState = new DashState();

    public IMoveable moveable {  get; private set; }

    public MovementStateManager(IMoveable moveable)
    {
        this.moveable = moveable;
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
}
