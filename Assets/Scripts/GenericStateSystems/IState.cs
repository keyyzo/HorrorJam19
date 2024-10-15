using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void Enter(); // Logic that runs when entering state

    public void Execute(); // Logic that runs continuously throughout the state, including condition to transition states

    public void Exit(); // Logic that runs when leaving the state
}
