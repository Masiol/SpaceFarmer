using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpaceBaseController : StructureControllerBase<StructureData>, IStructureController
{
    public StructureValuesPerLevel structureValuesPerLevel;
    public float GetValuesBonus()
    {
        Debug.Log(structureValuesPerLevel.StructureIncreasePerLevel[structureLevel - 1]);
        return structureValuesPerLevel.StructureIncreasePerLevel[structureLevel - 1];

    }
    public int GetStructureIndex()
    {
        return structureIndex;
    }

    public Sprite GetStructureIcon()
    {
        return structureImage;
    }

    public string GetStructureName()
    {
        return structureName;
    }

    public StructureData.StructureType GetStructureTypeBonus()
    {
        return structureType;
    }
    public int GetStructurePrice()
    {
        return structureValuesPerLevel.StructureCostPerLevel[structureLevel];
    }

    public int GetStructureLevel()
    {
        return structureLevel;
    }
    public void Upgrade(int amount)
    {
        StructureData structure = StructureManager.Instance.structures.FirstOrDefault(s => s.structureName == GetStructureName());
        if (structure != null)
        {
            structure.structureLevel += 1;
        }
        PlayerMoneyManager.Instance.SetAmount(-amount);
        this.structureLevel += 1;
        price = structureValuesPerLevel.StructureCostPerLevel[GetStructureLevel()];
        
    }
    StructureValuesPerLevel IStructureController.GetStructureValuesPerLevel()
    {
        return structureValuesPerLevel;
    }

    public void BuildStructure()
    {
        throw new System.NotImplementedException();
    }
}
