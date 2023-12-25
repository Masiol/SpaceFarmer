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
    private FarmIncomePerLevel farmIncomePerLevel;

    public void Initialize(IFarmUnit _farm, int _farmID, string _farmName, int _farmLevel, FarmIncomePerLevel _farmIncomePerLevel)
    {
        farmUnit = _farm;
        farmID = _farmID;
        farmName = _farmName;
        farmLevel = _farmLevel;
        farmIncomePerLevel = _farmIncomePerLevel;
        gameObject.GetComponent<FarmIncomeUI>().Initialize();
    }

    public void UpgradeProduce(IFarmUnit farm, int farmLevel)
    {
        throw new System.NotImplementedException();
    }

    public void Income()
    {
        currentFarmProduce += farmIncomePerLevel.farmIncomePerLevel[farmLevel];
        GetComponent<FarmIncomeUI>().StartAnimation(farmIncomePerLevel.farmIncomePerLevel[farmLevel]);
        PlayerMoneyManager.Instance.SetAmount(farmIncomePerLevel.farmIncomePerLevel[farmLevel] * (int)GetActiveBonus());
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
