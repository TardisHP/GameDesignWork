using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private string animBoolName;
    
    protected bool triggerCalled;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.animator.SetBool(animBoolName, true);
    }
    public virtual void Exit()
    {
        player.animator.SetBool(animBoolName, false);
        triggerCalled = false;
    }
    public virtual void Update()
    {
        Vector3 wpt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        wpt.z = player.transform.position.z;
        Vector3 vector = wpt - player.transform.position;
        if (vector.x != 0)
        {
            float scaleVal = player.transform.localScale.z;
            float scaleX = vector.x < 0 ? scaleVal : -scaleVal;
            player.transform.localScale = new Vector3(scaleX, scaleVal, scaleVal);
        }
    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
