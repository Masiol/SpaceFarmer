using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFarmUnit
{
    void Interact();
    void ExitInteractField();

    void UpdateFarmState();

    void Unlock();

    int GetPrice();
}
