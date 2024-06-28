using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public Transform menuTrans;
    public void StartGame1()
    {
        StartGame(1);
    }
    public void StartGame2()
    {
        StartGame(2);
    }
    public void StartGame3()
    {
        StartGame(3);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void StartGame(int mode)
    {
        menuTrans.DOMoveY(2400f, 2f)
            .SetEase(Ease.InCirc)
            .OnComplete(() =>
            {
                SceneManager.LoadScene(mode);
            });
    }
}
