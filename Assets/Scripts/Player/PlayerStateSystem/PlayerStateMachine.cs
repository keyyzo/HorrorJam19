using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStateMachine : BaseStateMachine
{
    public IState CurrentState { get; private set; }

    // reference to each state object

    public IdleState idleState;
    public WalkState walkState;
    public CrouchState crouchState;
    public RunState runState;

    // event to notify objects of state change

    public event Action<IState> stateChanged;

    public PlayerStateMachine(PlayerController player)
    {
        this.idleState = new IdleState(player);
        this.walkState = new WalkState(player);
        this.crouchState = new CrouchState(player);
        this.runState = new RunState(player);
    }

    public override void Initialize(IState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public override void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    public override void Update()
    {
        if (CurrentState != null)
        { 
            CurrentState.Update();
        }
    }
}
