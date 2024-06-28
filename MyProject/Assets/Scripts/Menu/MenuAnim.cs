using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnim : MonoBehaviour
{
    public Image colorGreen;
    public Image colorYellow;
    public Image title;
    public Image[] buttons;
    private void Start()
    {
        SetZero();
        colorGreen.transform.DOScale(Vector3.one, 1f)
            .SetEase(Ease.InExpo);
        colorYellow.transform.DOScale(Vector3.one, 1f)
            .SetEase(Ease.InExpo)
            .OnComplete(ShowTitle);
    }

    private void SetZero()
    {
        title.color = Vector4.zero;
        colorGreen.transform.localScale = Vector3.zero;
        colorYellow.transform.localScale = Vector3.zero;
        foreach (var button in buttons)
        {
            button.color = Vector4.zero;
            button.GetComponentInChildren<Text>().color = Vector4.zero;
        }
    }

    private void ShowTitle()
    {
        colorGreen.DOColor(new Vector4(1, 1, 1, 0.9f), 1f);
        colorYellow.DOColor(new Vector4(1, 1, 1, 0.9f), 1f);
        title.DOColor(Vector4.one, 1f)
            .SetEase(Ease.InCubic);
        foreach (var button in buttons)
        {
            button.DOColor(Vector4.one, 1f)
                .SetEase(Ease.InCubic);
            button.GetComponentInChildren<Text>().DOColor(new Vector4(0.42f, 0.25f, 0.13f, 1f), 1f)
                .SetEase(Ease.InCubic);
        }
    }
}
