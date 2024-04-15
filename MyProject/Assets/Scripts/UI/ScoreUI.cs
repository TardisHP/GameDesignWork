using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Bomb bomb;
    private Text text => GetComponent<Text>();
    private void Update()
    {
        text.text = bomb.killScore.ToString();
    }
}
