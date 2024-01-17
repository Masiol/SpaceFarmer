using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BackButton : MonoBehaviour
{
    private bool isShown;

    private void Start()
    {
        transform.GetComponent<RectTransform>().DOAnchorPosX(120, 0.25f);
        this.GetComponent<Button>().onClick.AddListener(BackManager.instance.HandleBack);
    }
    public void ManageButton(int ListObservableCount)
    {
        Debug.Log(ListObservableCount);
        if (ListObservableCount > 0)
        {
            transform.GetComponent<RectTransform>().DOAnchorPosX(-75, 0.25f);
        }
        else if (ListObservableCount == 0)
        {
            transform.GetComponent<RectTransform>().DOAnchorPosX(140, 0.25f);
        }
    }
}
