using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    public Image bulletImage => GetComponentInChildren<Image>();    // 子弹图片
    public Image chargeBar;
    private int chosenBullet = 0;   // 选择的子弹的下标
    private int bulletCount;    // 子弹种类的数量
    private float charge;
    private Color[] colors = { Color.blue, Color.red, Color.yellow, Color.black };
    private Player player => GetComponentInParent<Player>();
    private void Start()
    {
        bulletCount = bulletPrefab.Length;
        bulletImage.sprite = bulletPrefab[chosenBullet].GetComponent<SpriteRenderer>().sprite;
        charge = 0;
    }
    public void SwitchGun(int direction)
    {
        chosenBullet = (chosenBullet + direction + bulletCount) % bulletCount;
        bulletImage.sprite = bulletPrefab[chosenBullet].GetComponent<SpriteRenderer>().sprite;
    }
    public void Charge()
    {
        chargeBar.color = colors[chosenBullet];
        charge += Time.deltaTime;
        chargeBar.fillAmount = (1 + Mathf.Sin(7 * charge - Mathf.PI / 2)) / 2;
    }
    public void Shoot()
    {
        Vector3 wpt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        wpt.z = transform.position.z;
        Vector3 vector = wpt - transform.position;
        float angleWithYAxis = Vector3.Angle(Vector3.up, vector);
        angleWithYAxis = vector.x > 0 ? -angleWithYAxis : angleWithYAxis;
        GameObject bullet = Instantiate(bulletPrefab[chosenBullet], transform.position, Quaternion.Euler(0, 0, angleWithYAxis));
        bullet.GetComponent<Bullet>().alpha = chargeBar.fillAmount / 2f;
        bullet.GetComponent<Bullet>().Hit(vector.normalized);
        charge = 0;
        chargeBar.fillAmount = 0;
    }
}
