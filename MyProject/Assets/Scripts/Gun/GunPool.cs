using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPool : MonoBehaviour
{
    private Gun[] guns => GetComponentsInChildren<Gun>();
    private int chosenGun = 0;
    private int gunCount;
    private void Start()
    {
        gunCount = guns.Length;
        foreach (Gun gun in guns)
        {
            Canvas canvas = gun.GetComponentInChildren<Canvas>();
            canvas.enabled = false;
        }
        guns[chosenGun].GetComponentInChildren<Canvas>().enabled = true;
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

    }
}
