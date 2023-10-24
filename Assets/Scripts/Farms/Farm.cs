using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : IFarm
{
    public string FarmName { get; protected set; }

    public int FarmLevel { get; protected set; }

    public int FarmIndex { get; protected set; }

    public bool IsUnlocked { get; protected set; }

    public Farm(string name, int index, int farmLevel, bool isUnlocked)
    {
        FarmName = name;
        FarmIndex = index;
        FarmLevel = farmLevel;
        IsUnlocked = isUnlocked;
    }
    public void Unlock()
    {
        Debug.Log("Unlock farm");
    }

    public void Upgrade()
    {
        FarmLevel++;
        Debug.Log(FarmLevel);
    }
}
