using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStructureController
{
    int GetStructureIndex();
    Sprite GetStructureIcon();
    string GetStructureName();

    int GetStructurePrice();

    int GetStructureLevel();
    StructureData.StructureType GetStructureTypeBonus();

    void Upgrade(int amount);

    StructureValuesPerLevel GetStructureValuesPerLevel();

    void BuildStructure();
}
