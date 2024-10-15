using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine
{
    public abstract void Initialize(IState startingState);
    public abstract void TransitionTo(IState nextState);
    public abstract void Execute();
    
}
