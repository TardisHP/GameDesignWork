using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnim : MonoBehaviour
{
    public AudioController audioController;
    public Image colorGreen;
    public Image colorYellow;
    public Image title;
    public Image[] buttons;

    private float timer = 0;
    private void Start()
    {
        SetZero();
        Tween t = DOTween.To(() => timer, x => timer = x, 1, 1f)
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
        }
    }

    private void ShowTitle()
    {
        colorGreen.transform.localScale = Vector3.one;
        colorYellow.transform.localScale = Vector3.one;
        colorGreen.DOColor(new Vector4(1, 1, 1, 0.9f), 1f);
        colorYellow.DOColor(new Vector4(1, 1, 1, 0.9f), 1f);
        title.DOColor(Vector4.one, 1f)
            .SetEase(Ease.InCubic);
        foreach (var button in buttons)
        {
            button.DOColor(Vector4.one, 1f)
                .SetEase(Ease.InCubic);
        }
        Tween t = DOTween.To(() => timer, x => timer = x, 1, 1f)
            .OnComplete(() =>
            {
                // audioController.PlaySfx(audioController.showTitle);
                audioController.PlaySfx(audioController.bgmHand);
            });
    }
}
