using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoFarm : Farm
{
    public TomatoFarm(FarmData data) : base(data.farmName, data.farmIndex, data.farmLevel, data.farmIcon, data.price, data.isUnlocked, data.farmState)
    {
        GameObject.Find(data.farmName).GetComponent<FarmController>().Initialize(data.farmName, data.farmIndex, data.farmLevel, data.farmIcon, data.price, data.isUnlocked, data.farmState);
    }
}
