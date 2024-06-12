using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState

{
    
    public EnemyDeadState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (triggerCalled)
        {
            GameObject.Destroy(enemy.gameObject);
        }
    }
}
