using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitState : EnemyState
{
    private Vector3 moveDirection;
    private Transform player;
    public EnemyHitState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
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
        moveDirection = player.transform.position - enemy.transform.position;
        if (moveDirection.x != 0)
        {
            float scaleVal = enemy.transform.localScale.z;
            float scaleX = moveDirection.x > 0 ? scaleVal : -scaleVal;
            enemy.transform.localScale = new Vector3(scaleX, scaleVal, scaleVal);
        }
        if (enemy.rb.velocity.magnitude < 0.2f || triggerCalled)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
