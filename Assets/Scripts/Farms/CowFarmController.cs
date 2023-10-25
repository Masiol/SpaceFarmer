using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CowFarmController : MonoBehaviour, IFarmUnit
{
    public string farmName;
    public int farmIndex;
    public int farmLevel;
    public bool isUnlocked;
    public FarmData.FarmState FarmState;
    public void Initialize(string _name, int _index, int _level, bool _isUnlocked, FarmData.FarmState state)
    {
        farmName = _name;
        farmIndex = _index;
        farmLevel = _level;
        isUnlocked = _isUnlocked;
        FarmState = state;
    }

    public void Interact()
    {
        Debug.Log("interact with" + farmName);
    }
    public void ExitInteractField()
    {
        Debug.Log("no interact with" + farmName);
    }
}
