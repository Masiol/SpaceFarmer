using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FarmProduce: MonoBehaviour, IFarmProduce
{
    private IFarmUnit farmUnit;
    [SerializeField] private int farmID;
    [SerializeField] private string farmName;
    private int farmLevel;
    public int currentFarmProduce;
    private FarmValuesPerLevel farmValuesPerLevel;

    public void Initialize(IFarmUnit _farm, int _farmID, string _farmName, FarmValuesPerLevel _farmValuesPerLevel)
    {
        farmUnit = _farm;
        farmID = _farmID;
        farmName = _farmName;
        farmValuesPerLevel = _farmValuesPerLevel;
        gameObject.GetComponent<FarmIncomeUI>().Initialize();
    }

    public void Income()
    {
        currentFarmProduce += farmValuesPerLevel.farmIncomePerLevel[GetComponentInParent<FarmController>().GetLevel()];
        GetComponent<FarmIncomeUI>().StartAnimation(farmValuesPerLevel.farmIncomePerLevel[GetComponentInParent<FarmController>().GetLevel()]);
        PlayerMoneyManager.Instance.SetAmount(farmValuesPerLevel.farmIncomePerLevel[GetComponentInParent<FarmController>().GetLevel()] * (int)GetActiveBonus());
    }

    private float GetActiveBonus()
    {
        ActiveBonus activeBonus = FindObjectOfType<ActiveBonus>();
        if (activeBonus != null)
        {
            return activeBonus.GetCurrentMultiplier();
        }
        else
            return 1;
    }
}
