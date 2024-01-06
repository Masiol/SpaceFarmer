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

    public void Initialize(IFarmUnit _farm, int _farmID, string _farmName, int _farmLevel, FarmValuesPerLevel _farmValuesPerLevel)
    {
        farmUnit = _farm;
        farmID = _farmID;
        farmName = _farmName;
        farmLevel = _farmLevel;
        farmValuesPerLevel = _farmValuesPerLevel;
        gameObject.GetComponent<FarmIncomeUI>().Initialize();
    }

    public void Income()
    {
        currentFarmProduce += farmValuesPerLevel.farmIncomePerLevel[farmLevel];
        GetComponent<FarmIncomeUI>().StartAnimation(farmValuesPerLevel.farmIncomePerLevel[farmLevel]);
        PlayerMoneyManager.Instance.SetAmount(farmValuesPerLevel.farmIncomePerLevel[farmLevel] * (int)GetActiveBonus());
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
