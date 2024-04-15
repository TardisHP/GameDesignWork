using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    protected int chosenBullet = 0;   // ѡ�е��ӵ����±�
    protected int bulletCount;    // �ӵ����������
    protected Player player => GetComponentInParent<Player>();
    #region BulletState
    protected GameObject bulletToShoot; // ���ɵ���һ���ӵ�ʵ��
    protected Vector3 wpt;  // ���λ��
    protected Vector3 shootVector;  // ���ɵ��ӵ�Ҫ����ķ���
    protected float angleWithYAxis;
    #endregion
    protected void Start()
    {
        bulletCount = bulletPrefab.Length;
    }
    public void SwitchBullet(int direction)
    {
        chosenBullet = (chosenBullet + direction + bulletCount) % bulletCount;
    }
    /// <summary>
    /// ��ס����ʱ
    /// </summary>
    public virtual void ButtonKeepPress()
    {
        
    }
    /// <summary>
    /// �ɿ�����ʱ
    /// </summary>
    public virtual void ButtonUp()
    {
        
    }
    /// <summary>
    /// ���°���ʱ
    /// </summary>
    public virtual void ButtonDown()
    {

    }
    protected virtual void GenerateBullet()
    {
        // �����ӵ�ʵ��ͷ���
        wpt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        wpt.z = transform.position.z;
        shootVector = wpt - transform.position;
        angleWithYAxis = Vector3.Angle(Vector3.up, shootVector);
        angleWithYAxis = shootVector.x > 0 ? -angleWithYAxis : angleWithYAxis;
        bulletToShoot = Instantiate(bulletPrefab[chosenBullet], transform.position, Quaternion.Euler(0, 0, angleWithYAxis));
        // �����ӵ�����ֵ��������д
    }
    public Sprite GetCurrentBulletSprite()
    {
        return bulletPrefab[chosenBullet].GetComponent<SpriteRenderer>().sprite;
    }
}
