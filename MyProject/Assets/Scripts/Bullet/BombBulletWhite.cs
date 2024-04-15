using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBulletWhite : BombBullet
{
    private void Awake()
    {
        color = Color.white;
    }
    protected override void Update()
    {
        base.Update();
        if (boomtimer < 0)
        {
            boomtimer = 99f;
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
