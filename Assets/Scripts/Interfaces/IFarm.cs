using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFarm
{
    string FarmName { get; }
    int FarmLevel { get; }
    int FarmIndex {  get;}
    int Price { get; }
    bool IsUnlocked { get; }

}
