using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IColorChange
{
    private SpriteRenderer sprite => GetComponent<SpriteRenderer>();
    private ColorFixer colorFixer;
    private void Awake()
    {
        colorFixer = new ColorFixer();
        sprite.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
    public void ChangeColor(Color color, float t)
    {
        if (sprite.color == Color.white)
        {
            sprite.color = color;
        }
        else
        {
            sprite.color = colorFixer.Fix(sprite.color, color, t);
        }
    }
    public Color GetColor()
    {
        return sprite.color;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
