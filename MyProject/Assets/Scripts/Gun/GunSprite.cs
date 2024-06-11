using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSprite : MonoBehaviour
{
    private Vector3 wpt, direction;
    public Player player;
    private void Update()
    {
        transform.position = player.transform.position;

        wpt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        wpt.z = player.transform.position.z;
        direction = wpt - player.transform.position;
        direction = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (direction.x > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        else
            transform.rotation = Quaternion.Euler(new Vector3(-180, 0, -angle));

    }
}
