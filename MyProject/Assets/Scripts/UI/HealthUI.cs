using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject heartImg;
    private Stack<GameObject> hearts = new Stack<GameObject>();
    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject tmp = Instantiate(heartImg, transform);
            tmp.transform.localPosition = new Vector3(80 * i, 0, 0);
            hearts.Push(tmp);
        }
    }
    public void DeleteHeart()
    {
        if (hearts.Count > 0)
        {
            GameObject tmp = hearts.Pop();
            Destroy(tmp);
        }
    }
}
