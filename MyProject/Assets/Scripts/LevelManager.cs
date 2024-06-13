using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ScoreUI score;
    public EnemyPool enemyPool;
    public int level;
    private void Start()
    {
        level = 1;
    }
    private void Update()
    {
        if (score.GetScore() > level * 10)
        {
            enemyPool.ChangeGenerateLevel();
            level++;
        }
    }
}
