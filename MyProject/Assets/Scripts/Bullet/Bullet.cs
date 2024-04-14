using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Color color;  // 子弹的颜色
    public float alpha; // 调色的多少
    protected Rigidbody2D rb => GetComponent<Rigidbody2D>();

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果目标的颜色可以改变，则根据子弹的颜色改变目标的颜色
        IColorChange colorChangeable = collision.GetComponent<IColorChange>();
        if (colorChangeable != null )
        {
            colorChangeable.ChangeColor(color, alpha);
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Hit函数: 使子弹朝指定方向打出
    /// </summary>
    /// <param name="vector">子弹发射的方向param>
    public void Hit(Vector3 vector)
    {
        rb.AddForce(vector * 10f, ForceMode2D.Impulse);
    }
    public Color GetColor()
    {
        return color;
    }
}
