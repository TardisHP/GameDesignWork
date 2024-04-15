using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SniperGun : Gun
{
    public override void ButtonKeepPress()
    {
        base.ButtonKeepPress();
        //chargeBar.color = colors[chosenBullet];
        //charge += Time.deltaTime;
        //chargeBar.fillAmount = (1 + Mathf.Sin(7 * charge - Mathf.PI / 2)) / 2;
    }

    public override void ButtonUp()
    {
        base.ButtonUp();
        //bullet.GetComponent<Bullet>().alpha = chargeBar.fillAmount / 2f;
        //bullet.GetComponent<Bullet>().Hit(vector.normalized);
        //charge = 0;
        //chargeBar.fillAmount = 0;
    }
}
