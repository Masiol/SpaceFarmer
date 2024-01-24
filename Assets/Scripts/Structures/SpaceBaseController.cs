using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class LevelScalePair
{
    public int level;
    public Vector3 scale;
}

public class SpaceBaseController : StructureControllerBase<StructureData>, IStructureController
{
    [SerializeField] private StructureValuesPerLevel structureValuesPerLevel;
    [SerializeField] private GameObject ScalableStructureElement;  
    [SerializeField] private List<LevelScalePair> levelScalePairs;

    public float GetValuesBonus()
    {
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
        BuildStructure();
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
        LevelScalePair pair = levelScalePairs.Find(item => item.level == structureLevel);
        if (pair != null)
        {
            Vector3 scale = pair.scale;
            ScalableStructureElement.SetActive(true);
            ScalableStructureElement.GetComponent<RescaleStructure>().RescaleSingle(scale);
        }
        else
        {
            Debug.LogWarning($"Brak skali dla poziomu {structureLevel}.");
        }
    }
}
