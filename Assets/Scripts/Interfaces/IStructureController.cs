using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStructureController
{
    int GetStructureIndex();
    int GetStructurePrice();
    int GetStructureLevel();

    Sprite GetStructureIcon();
    string GetStructureName();

    
    StructureData.StructureType GetStructureTypeBonus(); 
    StructureValuesPerLevel GetStructureValuesPerLevel();

    void Upgrade(int amount);

    void BuildStructure();
}
