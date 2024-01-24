using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SolarPanelController : StructureControllerBase<StructureData>, IStructureController
{
    [SerializeField] private StructureValuesPerLevel structureValuesPerLevel;
    [SerializeField] private GameObject ScalableStructureElement;

    [SerializeField] private List<int> LevelToScaleNextObject;

    public float GetValuesBonus()
    {
        //Debug.Log(structureValuesPerLevel.StructureIncreasePerLevel[structureLevel - 1]);
        return structureValuesPerLevel.StructureIncreasePerLevel[structureLevel -1];
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
        if (LevelToScaleNextObject.Contains(structureLevel))
        {
            int scaleIndex = LevelToScaleNextObject.IndexOf(structureLevel);
            ScalableStructureElement.SetActive(true);
            ScalableStructureElement.GetComponent<RescaleStructure>().RescaleMultiple(scaleIndex);
        }
    }
}
