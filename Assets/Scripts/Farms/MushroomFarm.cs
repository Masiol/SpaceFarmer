using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomFarm : Farm
{
    MushroomFarmController mushroomFarmController;
    public MushroomFarm(FarmData data) : base(data.farmName, data.farmIndex, data.farmLevel,data.price, data.isUnlocked, data.farmState)
    {
        GameObject.FindObjectOfType<MushroomFarmController>().Initialize(data.farmName, data.farmIndex, data.farmLevel,data.price, data.isUnlocked , data.farmState);
    }

}
