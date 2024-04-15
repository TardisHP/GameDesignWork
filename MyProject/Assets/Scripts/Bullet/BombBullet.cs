using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BombBullet : Bullet
{
    protected StainGenerator stainGenerator => FindFirstObjectByType<StainGenerator>();
    protected float timer = 0f;
    protected float droptimer = 1f;
    protected float boomtimer = 99f;
    protected new void Start()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PointEffector2D>().forceMagnitude = 0f;
        Destroy(gameObject, 6f);
    }
    protected virtual void Update()
    {
        timer += Time.deltaTime;
        droptimer -= Time.deltaTime;
        boomtimer -= Time.deltaTime;
        transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(2.5f, 2.5f, 2.5f), timer);
        if (droptimer < 0)
        {
            droptimer = 99f;
            TouchGround();
            GetComponent<PointEffector2D>().forceMagnitude = 80f;
        }
        
    }
    protected void TouchGround()
    {
        boomtimer = .3f;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = false;
        // 在子弹处生成一滩爆炸痕迹
        stainGenerator.Generate(color, transform.position, Vector3.up, 1.5f, 2f);
        FindFirstObjectByType<PlayerEffect>().ShakeScreen();
    }
}
