using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public StainGenerator stainGenerator;
    public int killScore;
    private Color[][] colorArray;  // 储存可能出现的炸弹颜色
    private Queue<int> colorQueue;    // 储存炸弹颜色的序列
    public Color color; // 炸弹的颜色
    private Vector3 colorVector;    // 储存炸弹颜色的向量
    public EnemyPool enemyPool; // 场景中已有的敌人
    private ArrayList enemyToDelete = new ArrayList();  // 需要摧毁的敌人
    private Image bombImage => GetComponentInChildren<Image>();
    private Vector3 white = new Vector3(1f, 1f, 1f);
    public int type;   // 0:在颜料池子里取，1:随机
    private void Awake()
    {
        colorArray = new Color[2][];
        colorArray[0] = new Color[]{
            Color.red,
            Color.blue,
            Color.yellow,
            new Color(.3f, .6f, .4f),   // green
            new Color(.4f, 0, .4f),     // purple
            new Color(1f, .4f, .2f),    // orange
        };
        colorArray[1] = new Color[]{
            new Color(.3f, .6f, .4f),   // green
            new Color(.4f, 0, .4f),     // purple
            new Color(1f, .4f, .2f),    // orange
            new Color(.8f, .7f, .5f),    //
            new Color(.1f, .7f, .7f),    //
            new Color(.2f, .1f, .8f),    //
            new Color(.7f, .1f, .2f),    //
            new Color(.2f, .3f, .8f),    //
            new Color(.8f, .6f, .2f),    //
        };
        colorQueue = new Queue<int>();
    }
    private void Start()
    {
        GenerateColor();
        killScore = 0;
    }
    public void DeleteEnemy()
    {
        int i = 1;
        FindSameColorEnemy();
        if (enemyToDelete.Count > 0 )
        {
            stainGenerator.Generate(color, transform.position, Vector3.up, enemyToDelete.Count / 3, enemyToDelete.Count, enemyToDelete.Count);
            foreach (EnemyColor enemy in enemyToDelete)
            {
                enemyPool.enemies.Remove(enemy);
                enemy.DestroySelf();
                killScore += i++;
            }
            enemyToDelete.Clear();
            GenerateColor();
        }
    }
    private void FindSameColorEnemy()
    {
        foreach (EnemyColor enemy in enemyPool.enemies)
        {
            Vector3 enemyColorVector = ColorToVector(enemy.GetColor());
            // Debug.Log(colorVector);
            // Debug.Log(enemyColorVector);
            // Debug.Log(Vector3.Distance(enemyColorVector, colorVector));
            if (Vector3.Distance(enemyColorVector, colorVector) < 0.2f && enemyColorVector != white)
            {
                enemyToDelete.Add(enemy);
            }
        }
    }
    /// <summary>
    /// 为炸弹随机生成一种颜色
    /// </summary>
    private void GenerateColor()
    {
        if (colorQueue.Count == 0)
        {
            int c = 0;
            for (int i = 0; i < colorArray[type].Length; i++)
            {
                do
                {
                    c = Random.Range(0, colorArray[type].Length);

                } while (colorQueue.Contains(c));
                colorQueue.Enqueue(c);
            }
        }
        color = colorArray[type][colorQueue.Dequeue()];
        colorVector = ColorToVector(color);
        bombImage.color = color;
    }
    /// <summary>
    /// 把Color类型转为向量类型
    /// </summary>
    private Vector3 ColorToVector(Color color)
    {
        return new Vector3(color.r, color.g, color.b);
    }
}
