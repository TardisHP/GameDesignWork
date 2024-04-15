using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class SniperGun : Gun
{
    private float charge = 0f;
    private Color[] colors = { Color.blue, Color.red, Color.yellow, Color.black };
    public Image chargeBar;
    public override void ButtonKeepPress()
    {
        base.ButtonKeepPress();
        chargeBar.color = colors[chosenBullet];
        charge += Time.deltaTime;
        chargeBar.fillAmount = (1 + Mathf.Sin(7 * charge - Mathf.PI / 2)) / 2;
    }

    public override void ButtonUp()
    {
        base.ButtonUp();
        GenerateBullet();
        charge = 0;
        chargeBar.fillAmount = 0;
    }

    protected override void GenerateBullet()
    {
        base.GenerateBullet();
        bulletToShoot.GetComponent<Bullet>().alpha = chargeBar.fillAmount / 2f;
        bulletToShoot.GetComponent<Bullet>().Hit(shootVector.normalized);
    }
}
