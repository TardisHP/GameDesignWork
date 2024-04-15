using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEffect : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineImpulseSource screenShake;
    private Bomb bomb => GetComponentInChildren<Bomb>();
    private void Start()
    {
        screenShake = GetComponent<CinemachineImpulseSource>();
    }
    /// <summary>
    /// 按下空格时的特效
    /// </summary>
    public void BombEffect()
    {
        screenShake.GenerateImpulse();
        bomb.DeleteEnemy();
    }
    public void ShakeScreen()
    {
        screenShake.GenerateImpulse();
    }
}
