using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gun : MonoBehaviour
{
    protected AudioController audioController;

    public Sprite gunImg;

    public GameObject[] bulletPrefab;
    protected int chosenBullet = 0;   // 选中的子弹的下标
    protected int bulletTypeCount;    // 子弹种类的数量
    protected int bulletNum = -1;
    protected Player player => GetComponentInParent<Player>();

    #region BulletState
    protected GameObject bulletToShoot; // 生成的下一发子弹实体
    protected Vector3 wpt;  // 鼠标位置
    protected Vector3 shootVector;  // 生成的子弹要射向的方向
    protected float angleWithYAxis;
    #endregion

    protected void Start()
    {
        bulletTypeCount = bulletPrefab.Length;
        
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    public void SwitchBullet(int direction)
    {
        chosenBullet = (chosenBullet + direction + bulletTypeCount) % bulletTypeCount;
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
    /// <summary>
    /// 按下按键时
    /// </summary>
    public virtual void ButtonDown()
    {
    }
    protected virtual void GenerateBullet()
    {
          
        // 生成子弹实体和方向
        wpt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
