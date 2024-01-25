using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StructureValuesPerLevel", menuName = "StructureValuesPerLevel")]
public class StructureValuesPerLevel : ScriptableObject
{
    public List<float> StructureIncreasePerLevel = new List<float>();
    public List<int> StructureCostPerLevel = new List<int>();
}
