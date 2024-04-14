using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitState : EnemyState
{
    public EnemyHitState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.rb.velocity = Vector2.zero;
        enemy.rb.AddForce(enemy.moveVector * enemy.hitForce, ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        enemy.rb.velocity = Vector2.zero;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.rb.velocity.magnitude < 0.2f)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
