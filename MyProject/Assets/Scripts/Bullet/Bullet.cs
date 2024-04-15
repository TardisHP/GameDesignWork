using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Color color;  // 子弹的颜色
    public float alpha; // 调色的多少
    protected Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private void Start()
    {
        // n秒后自动销毁
        Destroy(gameObject, 5f);        
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果目标的颜色可以改变，则根据子弹的颜色改变目标的颜色
        IColorChange colorChangeable = collision.GetComponent<IColorChange>();
        if (colorChangeable != null )
        {
            colorChangeable.ChangeColor(color, alpha);
            Destroy(gameObject);
        }
        // 如果目标可以被玩家击退，则根据子弹的方向击退目标
        IHitByPlayer hitable = collision.GetComponent<IHitByPlayer>();
        if (hitable != null )
        {
            hitable.HitByPlayer(rb.velocity, 2 * alpha);
        }
        // 如果目标有打击粒子特效，则播放粒子系统
        IHitFX hitFXable = collision.GetComponent<IHitFX>();
        if (hitFXable != null)
        {
            hitFXable.PlayHitFX();
        }
    }
    /// <summary>
    /// Hit函数: 使子弹朝指定方向运动
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
