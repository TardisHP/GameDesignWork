using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRed : Bullet
{
    private void Awake()
    {
        color = Color.red;
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
