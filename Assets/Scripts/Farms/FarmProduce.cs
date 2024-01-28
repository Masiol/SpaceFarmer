using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FarmProduce: MonoBehaviour, IFarmProduce
{ 

    public int currentFarmProduce;   
    
    [SerializeField] private int farmID;
    [SerializeField] private string farmName;

    private IFarmUnit farmUnit; 
    private int farmLevel; 
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
        GetComponent<FarmIncomeUI>().StartAnimation(farmValuesPerLevel.farmIncomePerLevel[GetComponentInParent<FarmController>().GetLevel()] 
            * (int)ValueFromActiveBonus.instance.GetActiveBonusProduceIncrease()
            * ValueFromActiveBonus.instance.BonusFromStructureForIncreaseProduce());
        PlayerMoneyManager.Instance.SetAmount(farmValuesPerLevel.farmIncomePerLevel[GetComponentInParent<FarmController>().GetLevel()] 
            * (int)ValueFromActiveBonus.instance.GetActiveBonusProduceIncrease() 
            * ValueFromActiveBonus.instance.BonusFromStructureForIncreaseProduce());
    }
}
