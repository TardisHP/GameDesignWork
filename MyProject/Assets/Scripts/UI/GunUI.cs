using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUI : MonoBehaviour
{
    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
