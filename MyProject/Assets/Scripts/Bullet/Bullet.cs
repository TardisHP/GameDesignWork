using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Color color;  // �ӵ�����ɫ
    public float alpha; // ��ɫ�Ķ���
    protected Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private void Start()
    {
        // n����Զ�����
        Destroy(gameObject, 5f);        
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        // ���Ŀ�����ɫ���Ըı䣬������ӵ�����ɫ�ı�Ŀ�����ɫ
        IColorChange colorChangeable = collision.GetComponent<IColorChange>();
        if (colorChangeable != null )
        {
            colorChangeable.ChangeColor(color, alpha);
            Destroy(gameObject);
        }
        // ���Ŀ����Ա���һ��ˣ�������ӵ��ķ������Ŀ��
        IHitByPlayer hitable = collision.GetComponent<IHitByPlayer>();
        if (hitable != null )
        {
            hitable.HitByPlayer(rb.velocity, 2 * alpha);
        }
        // ���Ŀ���д��������Ч���򲥷�����ϵͳ
        IHitFX hitFXable = collision.GetComponent<IHitFX>();
        if (hitFXable != null)
        {
            hitFXable.PlayHitFX();
        }
    }
    /// <summary>
    /// Hit����: ʹ�ӵ���ָ�������˶�
    /// </summary>
    /// <param name="vector">�ӵ�����ķ���param>
    public void Hit(Vector3 vector)
    {
        rb.AddForce(vector * 10f, ForceMode2D.Impulse);
    }
    public Color GetColor()
    {
        return color;
    }
}
