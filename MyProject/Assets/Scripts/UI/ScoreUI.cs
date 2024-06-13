using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Bomb bomb;
    public TMP_Text endScore;
    private Text text => GetComponent<Text>();
    private void Update()
    {
        text.text = bomb.killScore.ToString();
        endScore.text = text.text;
    }
    public int GetScore()
    {
        return int.Parse(text.text);
    }
}
