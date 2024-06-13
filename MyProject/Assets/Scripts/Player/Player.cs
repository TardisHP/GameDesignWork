using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Animator animator;
    public Rigidbody2D rb;
    public PlayerController controller;
    public SpriteRenderer sprite;
    #endregion
    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerBombState bombState { get; private set; }
    public PlayerHitState hitState { get; private set; }
    public PlayerDeadState deadState { get; private set; }
    #endregion
    public bool canHurt;
    public int health;
    public PlayerDetector detector;
    public Canvas endCanvas;
    public bool canMove;
    public void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "isIdle");
        moveState = new PlayerMoveState(this, stateMachine, "isMove");
        bombState = new PlayerBombState(this, stateMachine, "isBomb");
        hitState = new PlayerHitState(this, stateMachine, "isHit");
        deadState = new PlayerDeadState(this, stateMachine, "isDead");
    }

    private void Start()
    {
        detector = GetComponent<PlayerDetector>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
        stateMachine.Initialize(idleState);
        canHurt = true;
        health = 5;
        endCanvas.enabled = false;
    }
    void Update()
    {
        stateMachine.currentState.Update();
    }
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
}


