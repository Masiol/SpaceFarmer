using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmStateController
{
    public FarmManager farmManager; // Referencja do FarmManager

    public void SetState()
    {
        farmManager = GameObject.FindObjectOfType<FarmManager>();
        SetFarmState();
    }

    private void SetFarmState()
    {
        List<FarmData> farms = farmManager.farms;
        int highestUnlockedIndexFarm = GetHighestUnlockedIndexFarm();
        int indexOfUnlockableFarm = highestUnlockedIndexFarm+1;

        for (int i = 0; i < farms.Count; i++)
        {
            FarmData farm = farms[i];
            if (i <= highestUnlockedIndexFarm)
            {
                farm.farmState = FarmData.FarmState.Unlocked;
            }
            else if (i == indexOfUnlockableFarm)
            {
                farm.farmState = FarmData.FarmState.Unlockable;
            }
            else
            {
                farm.farmState = FarmData.FarmState.Locked;
            }
        }
    }
    public int GetHighestUnlockedIndexFarm()
    {
        int highest = -1;
        for (int i = 0; i < farmManager.farms.Count; i++)
        {
            if (farmManager.farms[i].farmState == FarmData.FarmState.Unlocked)
            {
                highest++;
            }
        }

        return highest;
    }
}

