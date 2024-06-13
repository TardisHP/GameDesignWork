using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletState
{
    protected BulletStateMachine stateMachine;
    protected BulletAnimation bulletAnim;
    private string animBoolName;

    protected bool triggerCalled;

    public BulletState(BulletAnimation _bulletAnim, BulletStateMachine _stateMachine, string _animBoolName)
    {
        this.bulletAnim = _bulletAnim;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        bulletAnim.animator.SetBool(animBoolName, true);
    }
    public virtual void Exit()
    {
        bulletAnim.animator.SetBool(animBoolName, false);
        triggerCalled = false;
    }
    public virtual void Update()
    {
        // todo
    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
