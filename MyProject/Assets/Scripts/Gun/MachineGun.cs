using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MachineGun : Gun
{
    private float shootCoolTimer = 0f;
    private void Update()
    {
        shootCoolTimer += Time.deltaTime;
    }
    public override void ButtonKeepPress()
    {
        base.ButtonKeepPress();
        if (shootCoolTimer > .2f )
        {
            shootCoolTimer = 0f;
            GenerateBullet();
            
        }
    }
    public override void ButtonUp()
    {
        base.ButtonUp();
        if (shootCoolTimer > .2f)
        {
            shootCoolTimer = 0f;
            GenerateBullet();
        }
    }
    protected override void GenerateBullet()
    {       
        base.GenerateBullet();

        audioController.PlaySfx(audioController.machienGun);

        bulletToShoot.GetComponent<Bullet>().alpha = .1f;
        bulletToShoot.GetComponent<Bullet>().Hit(shootVector.normalized);
    }
}
