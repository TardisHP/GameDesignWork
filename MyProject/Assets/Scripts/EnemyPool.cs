using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Player player;
    public ArrayList enemies = new ArrayList();
    private float generateTimer;
    private int generateCount;
    private void Start()
    {
        generateTimer = 3f;
        generateCount = 6;
    }
    private void Update()
    {
        generateTimer += Time.deltaTime;
        if (generateTimer > 5f && generateCount > enemies.Count)
        {
            generateTimer = 0f;
            GameObject tmp = Instantiate(enemyPrefab, GeneratePosition(), Quaternion.identity);
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
}
