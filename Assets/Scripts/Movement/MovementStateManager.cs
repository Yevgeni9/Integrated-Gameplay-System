using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager
{
    MovementBaseState currentState;
    public IdleState idleState = new IdleState();
    public LeftState leftState = new LeftState();
    public RightState rightState = new RightState();
    public JumpState jumpState = new JumpState();

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
        currentState = state;
        state.EnterState(this);
    }
}
