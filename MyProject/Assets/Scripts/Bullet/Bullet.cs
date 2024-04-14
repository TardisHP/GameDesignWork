using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Color color;  // �ӵ�����ɫ
    public float alpha; // ��ɫ�Ķ���
    protected Rigidbody2D rb => GetComponent<Rigidbody2D>();

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        // ���Ŀ�����ɫ���Ըı䣬������ӵ�����ɫ�ı�Ŀ�����ɫ
        IColorChange colorChangeable = collision.GetComponent<IColorChange>();
        if (colorChangeable != null )
        {
            colorChangeable.ChangeColor(color, alpha);
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Hit����: ʹ�ӵ���ָ��������
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
