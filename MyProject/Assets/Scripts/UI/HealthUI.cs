using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Player player;
    private Text text => GetComponent<Text>();
    private void Update()
    {
        text.text = player.health.ToString();
    }
}
