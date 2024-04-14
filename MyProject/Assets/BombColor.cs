using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombColor : MonoBehaviour
{
    public Bomb bomb;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();  
    }

    // Update is called once per frame
    void Update()
    {
        image.color = bomb.color;
        //Debug.Log("111");
    }
}
