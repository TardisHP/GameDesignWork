using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBulletYellow : BombBullet
{
    private void Awake()
    {
        color = Color.yellow;
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        /*
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
        */
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.canHurt = false;
            player.sprite.color = color;
            player.gameObject.layer = LayerMask.NameToLayer("Invincible");
        }
        Damage damage = collision.GetComponent<Damage>();
        if (damage != null)
        {
            Destroy(damage.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.canHurt = true;
            player.sprite.color = Color.white;
            player.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
