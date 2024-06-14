using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public StainGenerator stainGenerator;
    public int killScore;
    private Color[][] colorArray;  // ������ܳ��ֵ�ը����ɫ
    private Queue<int> colorQueue;    // ����ը����ɫ������
    public Color color; // ը������ɫ
    private Vector3 colorVector;    // ����ը����ɫ������
    public EnemyPool enemyPool; // ���������еĵ���
    private ArrayList enemyToDelete = new ArrayList();  // ��Ҫ�ݻٵĵ���
    private Image bombImage => GetComponentInChildren<Image>();
    private Vector3 white = new Vector3(1f, 1f, 1f);
    public int type;   // 0:�����ϳ�����ȡ��1:���
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
    /// Ϊը���������һ����ɫ
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
    /// ��Color����תΪ��������
    /// </summary>
    private Vector3 ColorToVector(Color color)
    {
        return new Vector3(color.r, color.g, color.b);
    }
}
