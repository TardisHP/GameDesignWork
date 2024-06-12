using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BombGun : Gun
{
    private void Awake()
    {
        bulletNum = 3;
    }
    public override void ButtonDown()
    {
        base.ButtonDown();
        if (bulletNum > 0)
        {
            bulletNum--;
            GenerateBullet();
        }
        else if (bulletNum == 0)
        {
            return;
        }
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
        audioController.PlaySfx(audioController.bombGun);
        bulletToShoot.GetComponent<Bullet>().alpha = 1f;
        bulletToShoot.transform.position = wpt;
    }   
}
