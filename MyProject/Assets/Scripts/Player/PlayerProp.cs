using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProp : MonoBehaviour
{
    private PropCan can;
    public Image propImg;
    public Image effectImage;
    public EnemyPool enemyPool; // 场景中已有的敌人
    private AudioController audioController;
    public Queue<PropCan> canQueue;
    private void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
        canQueue = new Queue<PropCan>();
    }
    private void Update()
    {
        if (canQueue.Count > 0)
        {
            propImg.enabled = true;
            propImg.color = canQueue.Peek().canColor;
        }
        else
        {
            propImg.enabled = false;
        }
    }
    public void UseProp()
    {
        if  (canQueue.Count > 0)
        {
            PropCan can = canQueue.Dequeue();
            PlayEffect(can);
            foreach (EnemyColor enemy in enemyPool.enemies)
            {
                enemy.ChangeColor(can.canColor, 1);
            }
        }
    }
    private void PlayEffect(PropCan can)
    {
        Color tmp = can.canColor;
        tmp.a = 0;
        effectImage.color = tmp;
        effectImage.DOFade(1, 0.2f)
            .SetLoops(2, LoopType.Yoyo);

        // 播放音效
        audioController.PlaySfx(audioController.bomb);
    }
}
