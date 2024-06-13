using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class PropCanGenerator : MonoBehaviour
{
    public GameObject canPrefab;
    public PlayerProp playerProp;
    private float coolTimer;
    private void Start()
    {
        coolTimer = 0f;
    }
    private void Update()
    {
        if (playerProp.canQueue.Count == 0)
        {
            coolTimer += Time.deltaTime;
            if (coolTimer > 10f)
            {
                coolTimer = 0f;
                Instantiate(canPrefab, GeneratePosition(), Quaternion.identity);
            }
        }
    }
    private Vector3 GeneratePosition()
    {
        Vector3 pos = playerProp.transform.position;
        float length = Random.Range(3f, 5f);
        float angle = Random.Range(0f, 360f);
        pos += length * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        return pos;
    }
}
