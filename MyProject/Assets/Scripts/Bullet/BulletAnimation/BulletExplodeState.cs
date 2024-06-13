using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplodeState : BulletState
{
    public BulletExplodeState(BulletAnimation _bulletAnim, BulletStateMachine _stateMachine, string _animBoolName) : base(_bulletAnim, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        bulletAnim.rb.velocity = Vector3.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
