using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenFarm : Farm
{
    public ChickenFarm(FarmData data) : base(data.farmName, data.farmIndex, data.farmLevel, data.isUnlocked, data.farmState)
    {
        GameObject.FindObjectOfType<ChickenFarmController>().Initialize(data.farmName, data.farmIndex, data.farmLevel, data.isUnlocked, data.farmState);
    }
}
