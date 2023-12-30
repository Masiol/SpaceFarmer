using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFarmUnit
{
    void Interact(string currentFarmName);
    void ExitInteractField();

    void UpdateFarmState();

    void Unlock();

    int GetPrice();

    int GetLevel();

    string GetFarmName();

    void Upgrade();
}
