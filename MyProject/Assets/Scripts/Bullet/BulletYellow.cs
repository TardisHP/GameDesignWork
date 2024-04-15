using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletYellow : Bullet
{
    private void Awake()
    {
        color = Color.yellow;
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
