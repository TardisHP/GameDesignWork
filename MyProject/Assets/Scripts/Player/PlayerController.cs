using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private Gun gun => GetComponentInChildren<Gun>();
    private Bomb bomb => GetComponentInChildren<Bomb>();
    public Vector3 keyboardMoveAxes => playerInputAction.Player.Move.ReadValue<Vector2>();
    public float mouseRightButton => playerInputAction.Player.Charge.ReadValue<float>();
    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
    }
    private void OnEnable()
    {
        //��Ҫʹ�õ�ActionMap����
        playerInputAction.Player.Enable();
    }
    private void OnDisable()
    {
        //����ͬ��
        playerInputAction.Player.Disable();
    }
    private void Update()
    {
        //��֡���·����е�����д�Ķ�������
        MovePlayer();
        Charge();
    }
    private void MovePlayer()
    {
        rb.velocity = keyboardMoveAxes * 10f;
    }
    private void Charge()
    {
        if (mouseRightButton != 0)
        {
            gun.Charge();
        }
    }
    private void OnSwitchLeft(InputValue value)
    {
        gun.SwitchGun(-1);
    }
    private void OnSwitchRight(InputValue value)
    {
        gun.SwitchGun(1);
    }
    private void OnShoot(InputValue value)
    {
        gun.Shoot();
    }
    private void OnBomb(InputValue value)
    {
        bomb.DeleteEnemy();
    }
}
