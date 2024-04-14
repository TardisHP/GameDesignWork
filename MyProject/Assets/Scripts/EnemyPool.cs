using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public ArrayList enemies = new ArrayList();
    private void Awake()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject tmp = Instantiate(enemyPrefab, transform.position + new Vector3(-4 + 2*i, 3f, 0), Quaternion.identity);
            enemies.Add(tmp.GetComponent<Enemy>());
        }
    }
}
