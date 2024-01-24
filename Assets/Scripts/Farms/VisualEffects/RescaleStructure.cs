using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RescaleStructure : MonoBehaviour
{
    [SerializeField] private Vector3 destScale;
    [SerializeField] private float animTime;
    [SerializeField] private Ease ease;

    [SerializeField] private GameObject[] elements;
    [SerializeField] private GameObject element;
    [SerializeField] private bool doOnStart;

    private void Start()
    {
        if(doOnStart)
        {
            RescaleSingle(Vector3.one);
        }
    }

    public void RescaleMultiple(int index)
    {
        elements[index].transform.DOScale(destScale, animTime)
           .SetEase(ease);
    }

    public void RescaleSingle(Vector3 scale)
    {
        element.transform.DOScale(scale, animTime)
           .SetEase(ease);
    }
}
