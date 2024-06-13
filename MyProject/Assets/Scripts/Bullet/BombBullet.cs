using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BombBullet : Bullet
{
    private AudioController audioController;
    protected StainGenerator stainGenerator => FindFirstObjectByType<StainGenerator>();
    protected SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    protected float boomtimer = 99f;
    protected new void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();

        GetComponent<Collider2D>().enabled = false;
        GetComponent<PointEffector2D>().forceMagnitude = 0f;
        // 下落从小到大
        transform.localScale = Vector3.zero;
        transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f), 1f)
            .SetEase(Ease.InCirc)
            .SetLoops(1, LoopType.Restart)
            .OnComplete(TouchGround);
        // 颜色从黑到原色
        spriteRenderer.color = Color.black;
        spriteRenderer.DOColor(color, 1f)
            .SetEase(Ease.InCirc);
        Destroy(gameObject, 6f);
    }
    protected virtual void Update()
    {
        boomtimer -= Time.deltaTime;
    }
    protected void TouchGround()
    {
        boomtimer = .3f;
        GetComponent<Collider2D>().enabled = true;
        spriteRenderer.enabled = false;
        //播放爆炸音效
        audioController.PlaySfx(audioController.bombBullet);
        // 在子弹处生成一滩爆炸痕迹
        stainGenerator.Generate(color, transform.position, Vector3.up, 1.5f, 2f);
        FindFirstObjectByType<PlayerEffect>().ShakeScreen();
        // 弹开敌人
        GetComponent<PointEffector2D>().forceMagnitude = 80f;
    }
}
