using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStateMachine
{
    public BulletState currentState { get; private set; }

    public void Initialize(BulletState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(BulletState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
