using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PropCan : MonoBehaviour, IColorChange
{
    public Color canColor;
    private SpriteRenderer sprite;
    private ColorFixer colorFixer;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        colorFixer = new ColorFixer();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerProp playerProp = collision.gameObject.GetComponent<PlayerProp>();
        if (playerProp != null)
        {
            // 如果玩家有道具，则覆盖
            if (playerProp.canQueue.Count > 0)
            {
                playerProp.canQueue.Clear();
            }
            canColor = sprite.color;
            GetComponent<Collider2D>().enabled = false;
            sprite.enabled = false;
            playerProp.canQueue.Enqueue(this);
        }
    }
}
