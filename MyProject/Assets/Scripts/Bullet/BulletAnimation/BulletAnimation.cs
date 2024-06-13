using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.U2D;

public class BulletAnimation : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public BulletStateMachine stateMachine { get; private set; }
    public BulletFlyState flyState { get; private set; }
    public BulletExplodeState explodeState { get; private set; }
    public void Awake()
    {
        stateMachine = new BulletStateMachine();
        flyState = new BulletFlyState(this, stateMachine, "isFly");
        explodeState = new BulletExplodeState(this, stateMachine, "isExplode");
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(flyState);
    }
    void Update()
    {
        stateMachine.currentState.Update();
    }
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
