using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWhite : Bullet
{
    private void Awake()
    {
        color = Color.white;
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
