using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StainGenerator : MonoBehaviour
{
    public GameObject stainPrefab;
    public void Generate(Color color, Vector3 position, Vector3 direction, float scale, float radius)
    {
        // ��positionΪ���ķ��ѵ����ɸ�����ÿ�����ѵĽǶ����
        int splitNum = Random.Range(6, 9);  // ���������������ֵ��ʱд��
        Vector3[] splitDirs = new Vector3[splitNum];
        float angleDelta = 360f / splitNum;
        for (int i = 0; i < splitDirs.Length; i++)
        {
            var lastDir = i == 0 ? direction : splitDirs[i - 1];
            var angle = RandomNum(angleDelta, .2f);
            splitDirs[i] = Quaternion.AngleAxis(angle, Vector3.forward) * lastDir;
        }
        // ÿ�����ѷ����������ɸ�����
        foreach (var dir in splitDirs)
        {
            int stainNum = Random.Range(3, 6);
            float stainScale;    // ����
            float radiusDelta = radius / 6f;    // ÿ�����ռ��
            Vector3 stainPos = position;    // ����λ��
            for (int i = 0; i < stainNum; i++)
            {
                stainScale = scale - (i * scale / stainNum);    // ���������˥��
                stainPos += dir * RandomNum(radiusDelta, .4f);
                stainPos += (Vector3)Random.insideUnitCircle * RandomNum(radiusDelta * .2f, radiusDelta * .1f); // λ�����
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
        // ��positionΪ���ķ��ѵ����ɸ�����ÿ�����ѵĽǶ����
        int splitNum = num;
        Vector3[] splitDirs = new Vector3[splitNum];
        float angleDelta = 360f / splitNum;
        for (int i = 0; i < splitDirs.Length; i++)
        {
            var lastDir = i == 0 ? direction : splitDirs[i - 1];
            var angle = RandomNum(angleDelta, .2f);
            splitDirs[i] = Quaternion.AngleAxis(angle, Vector3.forward) * lastDir;
        }
        // ÿ�����ѷ����������ɸ�����
        foreach (var dir in splitDirs)
        {
            int stainNum = Random.Range(num, num + num / 2);
            float stainScale;    // ����
            float radiusDelta = radius / 6f;    // ÿ�����ռ��
            Vector3 stainPos = position;    // ����λ��
            for (int i = 0; i < stainNum; i++)
            {
                stainScale = scale - (i * scale / stainNum);    // ���������˥��
                stainPos += dir * RandomNum(radiusDelta, .4f);
                stainPos += (Vector3)Random.insideUnitCircle * RandomNum(radiusDelta * .2f, radiusDelta * .1f); // λ�����
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
