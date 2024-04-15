using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    protected int chosenBullet = 0;   // 选中的子弹的下标
    protected int bulletCount;    // 子弹种类的数量
    protected Player player => GetComponentInParent<Player>();
    #region BulletState
    protected GameObject bulletToShoot; // 生成的下一发子弹实体
    protected Vector3 shootVector;  // 生成的子弹要射向的方向
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
    /// 按住按键时
    /// </summary>
    public virtual void ButtonKeepPress()
    {
        
    }
    /// <summary>
    /// 松开按键时
    /// </summary>
    public virtual void ButtonUp()
    {
        
    }
    protected virtual void GenerateBullet()
    {
        // 生成子弹实体和方向
        Vector3 wpt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        wpt.z = transform.position.z;
        shootVector = wpt - transform.position;
        angleWithYAxis = Vector3.Angle(Vector3.up, shootVector);
        angleWithYAxis = shootVector.x > 0 ? -angleWithYAxis : angleWithYAxis;
        bulletToShoot = Instantiate(bulletPrefab[chosenBullet], transform.position, Quaternion.Euler(0, 0, angleWithYAxis));
        // 具体子弹的数值在子类中写
    }
    public Sprite GetCurrentBulletSprite()
    {
        return bulletPrefab[chosenBullet].GetComponent<SpriteRenderer>().sprite;
    }
}
