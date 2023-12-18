using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FarmIncomePerLevel", menuName = "FarmIncomePerLevel")]

public class FarmIncomePerLevel : ScriptableObject
{
    public List<int> farmIncomePerLevel = new List<int>();
}
