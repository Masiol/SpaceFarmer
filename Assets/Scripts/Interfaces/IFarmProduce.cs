using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFarmProduce
{
    public void Initialize(IFarmUnit farm, int farmID, string farmName, int farmlevel, FarmIncomePerLevel farmIncomePerLevel);
    public void UpgradeProduce();
}
