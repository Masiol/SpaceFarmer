using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowFarm : Farm
{
    public CowFarm(FarmData data) : base(data.farmName, data.farmIndex, data.farmLevel, data.isUnlocked, data.farmState)
    {
        GameObject.FindObjectOfType<CowFarmController>().Initialize(data.farmName, data.farmIndex, data.farmLevel, data.isUnlocked, data.farmState);
    }
}
