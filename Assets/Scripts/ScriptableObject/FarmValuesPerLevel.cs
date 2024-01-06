using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FarmValuesPerLevel", menuName = "FarmValuesPerLevel")]

public class FarmValuesPerLevel : ScriptableObject
{
    public List<int> farmIncomePerLevel = new List<int>();
    public List<int> farmCostPerLevel = new List<int>();
}
