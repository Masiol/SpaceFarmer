using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RescaleElement : MonoBehaviour
{

    [SerializeField] private Vector3 destScale;
    [SerializeField] private float animTime;
    [SerializeField] private Ease ease;

    void Start()
    {
        transform.DOScale(destScale, animTime)
           .SetEase(ease).OnComplete(() =>
           {
                   GetComponent<CollidersFarm>().EnableChildMeshColliders();
                   GetComponentInChildren<IFarmBehaviour>().StartProcess();
           });
    }

}
