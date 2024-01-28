using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBonusButton : MonoBehaviour
{
    public List<BonusData> bonusData = new List<BonusData>();
    public Button adButton;

    private BonusManager bonusManager;
    private void Start()
    {
        bonusManager = FindObjectOfType<BonusManager>();
        adButton.gameObject.SetActive(true);
        adButton.onClick.AddListener(SetBonus);
    }
    private void SetBonus()
    {
        bonusManager.CreateBonus(bonusData[1]);
    }
}
