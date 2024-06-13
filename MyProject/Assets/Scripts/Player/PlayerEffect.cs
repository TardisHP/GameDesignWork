using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerEffect : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Image bombEffectImage;
    private AudioController audioController;
    private CinemachineImpulseSource screenShake;
    private Bomb bomb => GetComponentInChildren<Bomb>();
    private void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
        screenShake = GetComponent<CinemachineImpulseSource>();
    }
    /// <summary>
    /// 按下空格时的特效
    /// </summary>
    public void BombEffect()
    {
        Color tmp = bomb.color;
        tmp.a = 0;
        bombEffectImage.color = tmp;
        bombEffectImage.DOFade(1, 0.2f)
            .SetLoops(2, LoopType.Yoyo);

        // 播放音效
        audioController.PlaySfx(audioController.bomb);
        // 屏幕震动
        screenShake.GenerateImpulse();
        bomb.DeleteEnemy();
    }
    public void ShakeScreen()
    {
        screenShake.GenerateImpulse();
    }
}
