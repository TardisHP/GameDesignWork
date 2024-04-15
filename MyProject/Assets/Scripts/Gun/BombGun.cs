using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BombGun : Gun
{
    public StainGenerator stainGenerator;
    public override void ButtonDown()
    {
        base.ButtonDown();
        GenerateBullet();
    }

    public override void ButtonKeepPress()
    {
        base.ButtonKeepPress();
    }

    public override void ButtonUp()
    {
        base.ButtonUp();
    }

    protected override void GenerateBullet()
    {
        base.GenerateBullet();
        bulletToShoot.GetComponent<Bullet>().alpha = 1f;
        bulletToShoot.transform.position = wpt;
        // 在子弹处生成一滩爆炸痕迹
        stainGenerator.Generate(bulletToShoot.GetComponent<Bullet>().GetColor(), wpt, Vector3.up, 1.5f, 2f);
    }
}
