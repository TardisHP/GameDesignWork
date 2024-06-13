using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TankColorDetector : MonoBehaviour
{
    private SpriteRenderer sprite => GetComponentInParent<SpriteRenderer>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IColorChange colorChangeable = collision.GetComponent<IColorChange>();
        if (colorChangeable != null)
        {
            colorChangeable.ChangeColor(sprite.color, 1);
        }
        IHitFX hitFXable = collision.GetComponent<IHitFX>();
        if (hitFXable != null)
        {
            hitFXable.PlayHitFX();
        }
    }
}
