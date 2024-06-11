using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour, IHitByPlayer, IHitFX
{
    #region Components
    public Animator animator;
    public Rigidbody2D rb;
    private StainGenerator stainGenerator => FindFirstObjectByType<StainGenerator>();
    private SpriteRenderer sprite => GetComponent<SpriteRenderer>();
    public ParticleSystem hitFX => GetComponentInChildren<ParticleSystem>();
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
    public GameObject damagePrefab;
    private float shootTimer;
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
        shootTimer = 0f;
    }
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    private void Update()
    {
        stateMachine.currentState.Update();
        shootTimer += Time.deltaTime;
        if (shootTimer > 3f)
        {
            shootTimer = 0f;
            ShootToPlayer();
        }
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
        stainGenerator.Generate(sprite.color, transform.position, moveVector, .5f, .15f);
    }

    public void PlayHitFX()
    {
        ParticleSystem.MainModule mainModule = hitFX.main;
        mainModule.startColor = sprite.color;
        hitFX.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 撞到玩家扣血
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            player.detector.ChangeHealth(transform);
        }
    }
    private void ShootToPlayer()
    {
        // 以position为中心分裂到若干个方向，每个分裂的角度随机
        int splitNum = Random.Range(6, 9);  // 分裂数量随机，数值暂时写死
        Vector3[] splitDirs = new Vector3[splitNum];
        float angleDelta = 360f / splitNum;
        for (int i = 0; i < splitDirs.Length; i++)
        {
            var lastDir = i == 0 ? Vector3.up : splitDirs[i - 1];
            var angle = RandomNum(angleDelta, .2f);
            splitDirs[i] = Quaternion.AngleAxis(angle, Vector3.forward) * lastDir;
        }
        // 每个分裂方向生成若干个污渍
        foreach (var dir in splitDirs)
        {
            var go = Instantiate(damagePrefab);
            go.transform.position = transform.position;
            go.transform.right = dir;
            go.GetComponent<Damage>().HitByVector(dir, 10f);
        }
    }
    private float RandomNum(float num, float randomness)
    {
        return num + Random.Range(-num * randomness, num * randomness);
    }
}
