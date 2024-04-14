using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public Color color;
    public EnemyPool enemyPool;
    private ArrayList enemyToDelete = new ArrayList();
    private Vector3 colorVector;
    private Image bombImage => GetComponentInChildren<Image>();
    private void Start()
    {
        GenerateColor();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DeleteEnemy();
            GenerateColor();
        }
    }

    private void DeleteEnemy()
    {
        FindSameColorEnemy();
        foreach (EnemyColor enemy in enemyToDelete)
        {
            enemyPool.enemies.Remove(enemy);
            enemy.DestroySelf();
        }
        enemyToDelete.Clear();
    }

    private void FindSameColorEnemy()
    {
        foreach (EnemyColor enemy in enemyPool.enemies)
        {
            Vector3 enemyColorVector = ColorToVector(enemy.GetColor());
            // Debug.Log(colorVector);
            // Debug.Log(enemyColorVector);
            // Debug.Log(Vector3.Distance(enemyColorVector, colorVector));
            if (Vector3.Distance(enemyColorVector, colorVector) < 0.3f)
            {
                enemyToDelete.Add(enemy);
            }
        }
    }

    private void GenerateColor()
    {
        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        colorVector = ColorToVector(color);
        bombImage.color = color;
    }
    private Vector3 ColorToVector(Color color)
    {
        return new Vector3(color.r, color.g, color.b);
    }
}
