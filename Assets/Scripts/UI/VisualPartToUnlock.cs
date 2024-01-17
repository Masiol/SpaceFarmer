using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class VisualPartToUnlock : MonoBehaviour
{
    [SerializeField] private Image Background;
    [SerializeField] private TextMeshProUGUI PriceText;

    public event Action OnAnimationCompleted;

    public void StartAnimation()
    {
        Background.GetComponent<RectTransform>().DOScale(Vector3.zero, 0.35f)
            .SetEase(Ease.InExpo)
            .OnComplete(() => AnimationCompleted());

        PriceText.GetComponent<RectTransform>().DOScale(Vector3.zero, 0.35f)
            .SetEase(Ease.InCirc);
    }

    private void AnimationCompleted()
    {
        // Wywo³aj zdarzenie, gdy animacja zostanie zakoñczona
        OnAnimationCompleted?.Invoke();
    }
}
