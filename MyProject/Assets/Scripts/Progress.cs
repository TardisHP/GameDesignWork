using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public EnemyPool enemyPool;
    private Image progressImg;
    private int enemyAccount;
    private const float MAXACCOUNT = 10.0f;
    private void Start()
    {
        progressImg = GetComponent<Image>();
    }
    private void Update()
    {
        enemyAccount = enemyPool.enemies.Count;
        progressImg.fillAmount = enemyAccount / MAXACCOUNT;
    }
}
