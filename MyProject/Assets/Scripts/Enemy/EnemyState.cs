using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    private string animBoolName;

    protected bool triggerCalled;

    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemy = _enemy;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        enemy.animator.SetBool(animBoolName, true);
    }
    public virtual void Exit()
    {
        enemy.animator.SetBool(animBoolName, false);
        triggerCalled = false;
    }
    public virtual void Update()
    {
        Vector3 vector = enemy.rb.velocity;
        if (vector.x != 0)
        {
            float scaleVal = enemy.transform.localScale.z;
            float scaleX = vector.x > 0 ? scaleVal : -scaleVal;
            enemy.transform.localScale = new Vector3(scaleX, scaleVal, scaleVal);
        }
    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
