using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBonus : MonoBehaviour
{
    [SerializeField] private Transform UIBonusParent;
    [SerializeField] private RectTransform bonusPrefab;

    public void SetBonusOnScreen(Bonus bonus)
    {
        if (bonusPrefab != null)
        {
            var go = Instantiate(bonusPrefab, UIBonusParent);
            go.transform.SetParent(UIBonusParent, false);
            go.gameObject.AddComponent<ActiveBonus>();
            go.GetComponent<ActiveBonus>().Initialize(bonus);
        }
    }
}
