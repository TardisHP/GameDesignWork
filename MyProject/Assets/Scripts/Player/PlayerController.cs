using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    private Mouse mouse = Mouse.current;
    private Vector3 keyboardMoveAxes => playerInputAction.Player.Move.ReadValue<Vector2>();
    private float mouseRightButton => playerInputAction.Player.KeepPress.ReadValue<float>();
    private Player player => GetComponent<Player>();
    private GunPool guns => GetComponentInChildren<GunPool>();
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
    public void OnDisable()
    {
        //上述同理
        playerInputAction.Player.Disable();
    }
    public void MovePlayer()
    {
        player.rb.velocity = keyboardMoveAxes * 4f;
    }
    public void KeepPress()
    {
        if (mouseRightButton != 0)
        {
            guns.GetChosenGun().ButtonKeepPress();
        }
    }
    public void MouseMiddleButton()
    {
        float val = mouse.scroll.y.ReadValue();
        if (val != 0f)
        {
            guns.SwitchGun(val > 0 ? 1 : -1);
        }
    }
    private void OnSwitchLeft(InputValue value)
    {
        guns.GetChosenGun().SwitchBullet(-1);
    }
    private void OnSwitchRight(InputValue value)
    {
        guns.GetChosenGun().SwitchBullet(1);
    }
    private void OnButtonUp(InputValue value)
    {
        guns.GetChosenGun().ButtonUp();
    }
    private void OnButtonDown(InputValue value)
    {
        
        guns.GetChosenGun().ButtonDown();
    }
    private void OnBomb(InputValue value)
    {
        player.stateMachine.ChangeState(player.bombState);
    }
    private void OnProp(InputValue value)
    {
        player.GetComponent<PlayerProp>().UseProp();
    }
}
