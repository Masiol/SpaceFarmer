using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VisualPartAfterUnlock : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    public void StartAnimation()
    {
        Panel.transform.DOScale(new Vector3(0.61109f, 0.61109f, 0.61109f), 0.5f)
            .SetEase(Ease.InOutSine);
    }
}
