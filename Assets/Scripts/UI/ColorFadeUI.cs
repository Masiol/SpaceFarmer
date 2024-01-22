using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorFadeUI : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private float animateTime;
    [SerializeField] private Ease ease;
    void Start()
    {
        this.GetComponent<UnityEngine.UI.Image>().DOFade(0.65f, 0.25f).SetDelay(delay).SetEase(ease);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
