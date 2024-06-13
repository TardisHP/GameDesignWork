using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Player player;
    public ArrayList enemies = new ArrayList();
    private float generateTimer;
    [SerializeField] private float generateLevel;    // 生成敌人的时间间隔
    private int generateCount;
    public bool canMove;
    private void Start()
    {
        generateTimer = 3f;
        generateLevel = 5f;
        generateCount = 24; //敌人上限
    }
    private void Update()
    {
        generateTimer += Time.deltaTime;
        if (generateTimer > generateLevel && generateCount > enemies.Count)
        {
            generateTimer = 0f;
            GameObject tmp = Instantiate(enemyPrefab, GeneratePosition(), Quaternion.identity);
            tmp.GetComponent<Enemy>().canMove = canMove;
            enemies.Add(tmp.GetComponent<EnemyColor>());
        }
    }
    private Vector3 GeneratePosition()
    {
        Vector3 pos = player.transform.position;
        float length = Random.Range(3f, 5f);
        float angle = Random.Range(0f, 360f);
        pos += length * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        return pos;
    }
    public void ChangeGenerateLevel()
    {
        generateLevel = generateLevel / 1.5f + 1f;
    }
}
