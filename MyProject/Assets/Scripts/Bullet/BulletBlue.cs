using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBlue : Bullet
{

    private void Awake()
    {
        color = Color.blue;
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
