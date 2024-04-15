using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : Bullet
{
    private float timer = .3f;    // 爆炸斥力持续时间
    private void Awake()
    {
        color = Color.white;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 99f;
            GetComponent<PointEffector2D>().forceMagnitude = 0f;
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        IColorChange colorChangeable = collision.GetComponent<IColorChange>();
        if (colorChangeable != null)
        {
            colorChangeable.ChangeColor(color, alpha);
        }
        IHitFX hitFXable = collision.GetComponent<IHitFX>();
        if (hitFXable != null)
        {
            hitFXable.PlayHitFX();
        }
    }
}
