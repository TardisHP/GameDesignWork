using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPool : MonoBehaviour
{
    private Gun[] guns;
    private int chosenGun = 0;
    private int gunCount;
    
    // public SpriteRenderer gunSpriteRenderer;
    public GunUI gunUI;

    private void Start()
    {
        guns = GetComponentsInChildren<Gun>();
        gunCount = guns.Length;
        foreach (Gun gun in guns)
        {
            Canvas canvas = gun.GetComponentInChildren<Canvas>();
            canvas.enabled = false;
        }
        guns[chosenGun].GetComponentInChildren<Canvas>().enabled = true;
        // …Ë÷√UIÃ˘Õº
        // gunSpriteRenderer.sprite = guns[chosenGun].gunImg;
        // gunUI.SetSprite(guns[chosenGun].gunImg);
    }
    public Gun GetChosenGun()
    {
        return guns[chosenGun];
    }
    public void SwitchGun(int direction)
    {
        Canvas canvas = guns[chosenGun].GetComponentInChildren<Canvas>();
        canvas.enabled = false;
        chosenGun = (chosenGun + direction + gunCount) % gunCount;
        canvas = guns[chosenGun].GetComponentInChildren<Canvas>();
        canvas.enabled = true;
        // …Ë÷√UIÃ˘Õº
        // gunSpriteRenderer.sprite = guns[chosenGun].gunImg;
        gunUI.SetSprite(guns[chosenGun].gunImg);
    }
}
