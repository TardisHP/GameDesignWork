using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMoveState : EnemyState
{
    private Transform player;
    private float moveSpeed = 2f;
    private Vector3 moveDirection;
    public EnemyMoveState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.canMove)
        {
            moveDirection = player.transform.position - enemy.transform.position;
            Move();
        }
    }
    private void Move()
    {
        // enemy.transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
        enemy.rb.velocity = moveDirection.normalized * moveSpeed;
    }
}
