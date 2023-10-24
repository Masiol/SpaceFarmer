using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenFarmController : MonoBehaviour, IFarmUnit
{
    public string farmName;
    public int farmIndex;
    public int farmLevel;
    public bool isUnlocked;

    public void Initialize(string _name, int _index, int _level, bool _isUnlocked)
    {
        farmName = _name;
        farmIndex = _index;
        farmLevel = _level;
        isUnlocked = _isUnlocked;
    }

    public void Interact()
    {
        Debug.Log("interact with player chicken farm");
    }
}
