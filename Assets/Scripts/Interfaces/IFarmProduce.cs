using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFarmProduce
{
    public void Initialize(IFarmUnit farm, int farmID, string farmName, float multiplier, int farmlevel);
    public void UpgradeProduce(IFarmUnit farm, int farmLevel);

    public float CollectedMoney();

    public float CalculateMoneyToGenerate();
}
