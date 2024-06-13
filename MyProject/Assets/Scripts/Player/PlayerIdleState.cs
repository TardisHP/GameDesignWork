using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerIdleState : PlayerState
{
    private Vector3 wpt;
    private Vector3 shootVector;
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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
        wpt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        wpt.z = player.transform.position.z;
        shootVector = wpt - player.transform.position;
        shootVector = shootVector.normalized;
        player.animator.SetFloat("mousePosX", shootVector.x);
        player.animator.SetFloat("mousePosY", shootVector.y);

        if (player.canMove)
        {
            player.controller.MovePlayer();
        }
        player.controller.KeepPress();
        player.controller.MouseMiddleButton();
        if (player.rb.velocity != Vector2.zero)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
