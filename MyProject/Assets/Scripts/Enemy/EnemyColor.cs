using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColor : MonoBehaviour, IColorChange
{
    private SpriteRenderer sprite => GetComponent<SpriteRenderer>();
    private Enemy enemy => GetComponent<Enemy>();
    private ColorFixer colorFixer;

    private float resetTimer;   // ÖØÖÃÑÕÉ«

    private void Awake()
    {
        colorFixer = new ColorFixer();
        resetTimer = 0f;
        // sprite.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
    private void Update()
    {
        if (sprite.color != Color.white)
        {
            resetTimer += Time.deltaTime;
            if (resetTimer > 7f)
            {
                resetTimer = 0f;
                ChangeColor(Color.white, 1);
            }
        }
    }
    public void ChangeColor(Color color, float t)
    {
        resetTimer = 0f;
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
        enemy.DestroySelf();
    }
}
