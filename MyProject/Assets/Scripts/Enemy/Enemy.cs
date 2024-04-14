using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour, IHitByPlayer
{
    #region Components
    public Animator animator;
    public Rigidbody2D rb;
    #endregion
    #region States
    public EnemyStateMachine stateMachine { get; private set; }
    public EnemyIdleState idleState { get; private set; }
    public EnemyHitState hitState { get; private set; }
    public EnemyMoveState moveState { get; private set; }
    public EnemyDeadState deadState { get; private set; }
    #endregion
    #region Attributes
    public Vector2 moveVector;
    public float hitForce;
    #endregion
    private void Awake()
    {
        stateMachine = new EnemyStateMachine();
        idleState = new EnemyIdleState(this, stateMachine, "isIdle");
        hitState = new EnemyHitState(this, stateMachine, "isHit");
        moveState = new EnemyMoveState(this, stateMachine, "isMove");
        deadState = new EnemyDeadState(this, stateMachine, "isDead");
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(idleState);
    }
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    private void Update()
    {
        stateMachine.currentState.Update();
    }

    public void HitByPlayer(Vector2 vector, float force)
    {
        moveVector = vector;
        hitForce = force;
        stateMachine.ChangeState(hitState);
    }
    public void DestroySelf()
    {
        stateMachine.ChangeState(deadState);
    }
}
