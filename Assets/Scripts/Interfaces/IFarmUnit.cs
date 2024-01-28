using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IFarmUnit
{
    int GetPrice();
    int GetLevel();
    Sprite GetFarmIcon();
    string GetFarmName();
    void Interact(string currentFarmName);
    void ExitInteractField();
    void UpdateFarmState();
    void Upgrade(int amount);
    Task Unlock();   
}
