using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownUI : MonoBehaviour
{
    public float timeRemaining = 60f; // 初始倒计时时间
    public Text countdownText; // 用于显示倒计时的文本组件
    public Player player;

    void Update()
    {
        // 如果倒计时大于0，则继续减少时间
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // 减去每帧的时间
            UpdateCountdownUI(); // 更新倒计时文本
        }
        else
        {
            timeRemaining = 0; // 倒计时结束，确保时间不为负值
            // 在此添加倒计时结束后的逻辑，比如游戏结束、显示成绩等
            player.stateMachine.ChangeState(player.deadState);
            player.endCanvas.enabled = true;
            player.DestroySelf();
        }
    }

    void UpdateCountdownUI()
    {
        // 将时间格式化为分钟和秒数
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);

        // 更新倒计时文本显示
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
