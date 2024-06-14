using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownUI : MonoBehaviour
{
    public float timeRemaining = 60f; // ��ʼ����ʱʱ��
    public Text countdownText; // ������ʾ����ʱ���ı����
    public Player player;

    void Update()
    {
        // �������ʱ����0�����������ʱ��
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // ��ȥÿ֡��ʱ��
            UpdateCountdownUI(); // ���µ���ʱ�ı�
        }
        else
        {
            timeRemaining = 0; // ����ʱ������ȷ��ʱ�䲻Ϊ��ֵ
            // �ڴ���ӵ���ʱ��������߼���������Ϸ��������ʾ�ɼ���
            player.stateMachine.ChangeState(player.deadState);
            player.endCanvas.enabled = true;
            player.DestroySelf();
        }
    }

    void UpdateCountdownUI()
    {
        // ��ʱ���ʽ��Ϊ���Ӻ�����
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);

        // ���µ���ʱ�ı���ʾ
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
