using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    AudioController audioController;

    public StainGenerator stainGenerator;
    public int killScore;
    private Color[] colorArray;  // 储存可能出现的炸弹颜色
    private Queue<int> colorQueue;    // 储存炸弹颜色的序列
    public Color color; // 炸弹的颜色
    private Vector3 colorVector;    // 储存炸弹颜色的向量
    public EnemyPool enemyPool; // 场景中已有的敌人
    private ArrayList enemyToDelete = new ArrayList();  // 需要摧毁的敌人
    private Image bombImage => GetComponentInChildren<Image>();
    private Vector3 white = new Vector3(1f, 1f, 1f);
    private void Awake()
    {
        colorArray = new Color[]{
            Color.red,
            Color.green,
            Color.blue,
            Color.yellow,
            new Color(0f, 1f, 1f),
            new Color(1f, 0f, 1f),
            new Color(1f, 1f, 0f),
        };
        colorQueue = new Queue<int>();
    }
    private void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();

        GenerateColor();
        killScore = 0;
    }
    public void DeleteEnemy()
    {
        int i = 1;
        FindSameColorEnemy();
        if (enemyToDelete.Count > 0 )
        {
            audioController.PlaySfx(audioController.gun);

            stainGenerator.Generate(color, transform.position, Vector3.up, enemyToDelete.Count / 3, enemyToDelete.Count, enemyToDelete.Count);
            foreach (EnemyColor enemy in enemyToDelete)
            {
                enemyPool.enemies.Remove(enemy);
                enemy.DestroySelf();
                killScore += i++;
            }
            enemyToDelete.Clear();
        }
        GenerateColor();
    }
    private void FindSameColorEnemy()
    {
        foreach (EnemyColor enemy in enemyPool.enemies)
        {
            Vector3 enemyColorVector = ColorToVector(enemy.GetColor());
            // Debug.Log(colorVector);
            // Debug.Log(enemyColorVector);
            // Debug.Log(Vector3.Distance(enemyColorVector, colorVector));
            if (Vector3.Distance(enemyColorVector, colorVector) < 0.5f && enemyColorVector != white)
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
            for (int i = 0; i < colorArray.Length; i++)
            {
                do
                {
                    c = Random.Range(0, colorArray.Length);

                } while (colorQueue.Contains(c));
                colorQueue.Enqueue(c);
            }
        }
        color = colorArray[colorQueue.Dequeue()];
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
