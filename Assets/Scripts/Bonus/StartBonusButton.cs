using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBonusButton : MonoBehaviour
{
    public List<BonusData> bonusData = new List<BonusData>();
    BonusManager bonusManager;
    public Button adButton;

    private void Start()
    {
        bonusManager = FindObjectOfType<BonusManager>();
        adButton.gameObject.SetActive(true);
        adButton.onClick.AddListener(SetBonus);
    }

    private void SetBonus()
    {
        //BonusManager bonusManager = new BonusManager();
        bonusManager.CreateBonus(bonusData[1]);
    }
}
