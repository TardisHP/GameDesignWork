using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StainGenerator : MonoBehaviour
{
    public GameObject stainPrefab;
    public void Generate(Color color, Vector3 position, Vector3 direction, float scale, float radius)
    {
        // 以position为中心分裂到若干个方向，每个分裂的角度随机
        int splitNum = Random.Range(6, 9);  // 分裂数量随机，数值暂时写死
        Vector3[] splitDirs = new Vector3[splitNum];
        float angleDelta = 360f / splitNum;
        for (int i = 0; i < splitDirs.Length; i++)
        {
            var lastDir = i == 0 ? direction : splitDirs[i - 1];
            var angle = RandomNum(angleDelta, .2f);
            splitDirs[i] = Quaternion.AngleAxis(angle, Vector3.forward) * lastDir;
        }
        // 每个分裂方向生成若干个污渍
        foreach (var dir in splitDirs)
        {
            int stainNum = Random.Range(3, 6);
            float stainScale;    // 污渍
            float radiusDelta = radius / 6f;    // 每个污渍间距
            Vector3 stainPos = position;    // 污渍位置
            for (int i = 0; i < stainNum; i++)
            {
                stainScale = scale - (i * scale / stainNum);    // 缩放随距离衰减
                stainPos += dir * RandomNum(radiusDelta, .4f);
                stainPos += (Vector3)Random.insideUnitCircle * RandomNum(radiusDelta * .2f, radiusDelta * .1f); // 位置随机
                var go = Instantiate(stainPrefab);
                go.transform.position = stainPos;
                go.transform.right = dir;
                go.transform.localScale = new Vector3(stainScale, stainScale, 1f);
                go.transform.parent = transform;
                go.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }
    public void Generate(Color color, Vector3 position, Vector3 direction, float scale, float radius, int num)
    {
        // 以position为中心分裂到若干个方向，每个分裂的角度随机
        int splitNum = num;
        Vector3[] splitDirs = new Vector3[splitNum];
        float angleDelta = 360f / splitNum;
        for (int i = 0; i < splitDirs.Length; i++)
        {
            var lastDir = i == 0 ? direction : splitDirs[i - 1];
            var angle = RandomNum(angleDelta, .2f);
            splitDirs[i] = Quaternion.AngleAxis(angle, Vector3.forward) * lastDir;
        }
        // 每个分裂方向生成若干个污渍
        foreach (var dir in splitDirs)
        {
            int stainNum = Random.Range(num, num + num / 2);
            float stainScale;    // 污渍
            float radiusDelta = radius / 6f;    // 每个污渍间距
            Vector3 stainPos = position;    // 污渍位置
            for (int i = 0; i < stainNum; i++)
            {
                stainScale = scale - (i * scale / stainNum);    // 缩放随距离衰减
                stainPos += dir * RandomNum(radiusDelta, .4f);
                stainPos += (Vector3)Random.insideUnitCircle * RandomNum(radiusDelta * .2f, radiusDelta * .1f); // 位置随机
                var go = Instantiate(stainPrefab);
                if (i == 0)
                    stainPos = position;
                go.transform.position = stainPos;
                go.transform.right = dir;
                go.transform.localScale = new Vector3(stainScale, stainScale, 1f);
                go.transform.parent = transform;
                go.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }
    private float RandomNum(float num, float randomness)
    {
        return num + Random.Range(-num * randomness, num * randomness);
    }

}
