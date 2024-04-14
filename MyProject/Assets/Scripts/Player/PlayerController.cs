using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    public Vector3 keyboardMoveAxes => playerInputAction.Player.Move.ReadValue<Vector2>();
    public float mouseRightButton => playerInputAction.Player.Charge.ReadValue<float>();
    private Player player => GetComponent<Player>();
    private Gun gun => GetComponentInChildren<Gun>();
    void Awake()
    {
        //实例化InputActions脚本
        playerInputAction = new PlayerInputAction();
    }
    private void OnEnable()
    {
        //将要使用的ActionMap开启
        playerInputAction.Player.Enable();
    }
    private void OnDisable()
    {
        //上述同理
        playerInputAction.Player.Disable();
    }
    public void MovePlayer()
    {
        player.rb.velocity = keyboardMoveAxes * 10f;
    }
    public void Charge()
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
        player.stateMachine.ChangeState(player.bombState);
    }
}
