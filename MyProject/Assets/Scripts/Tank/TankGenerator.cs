using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGenerator : MonoBehaviour
{
    public GameObject tankPrefab;
    public Player player;
    private float coolTimer;
    private int num;
    private void Start()
    {
        coolTimer = 15f;
        num = 0;
    }
    private void Update()
    {
        coolTimer += Time.deltaTime;
        if (coolTimer > 20f)
        {
            Instantiate(tankPrefab, GeneratePosition(), Quaternion.identity);
            coolTimer = 0f;
            num++;
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
