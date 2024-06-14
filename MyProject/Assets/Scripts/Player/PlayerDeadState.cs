using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.GetComponent<Collider2D>().enabled = false;
        foreach(EnemyColor enemy in player.enemyPool.enemies)
        {
            enemy.GetComponent<Enemy>().stateMachine.ChangeState(enemy.GetComponent<Enemy>().deadState);
        }
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
            // player.transform.DOScale(Vector3.zero, 1);
            player.endCanvas.enabled = true;
            player.DestroySelf();
        }
    }
}
