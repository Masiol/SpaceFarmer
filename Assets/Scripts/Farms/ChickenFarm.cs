using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenFarm : Farm
{
    public ChickenFarm(FarmData data) : base(data.farmName, data.farmIndex, data.farmLevel,data.price, data.isUnlocked, data.farmState)
    {
        GameObject.Find(data.farmName).GetComponent<FarmController>().Initialize(data.farmName, data.farmIndex, data.farmLevel, data.price, data.isUnlocked, data.farmState);
    }
}
