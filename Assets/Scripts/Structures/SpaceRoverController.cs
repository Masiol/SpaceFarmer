using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class LevelSpeedPair
{
    public int level;
    public float speed;
}
public class SpaceRoverController : StructureControllerBase<StructureData>, IStructureController
{

    [SerializeField] private StructureValuesPerLevel structureValuesPerLevel;
    [SerializeField] private GameObject ScalableStructureElement;
    [SerializeField] private List<LevelSpeedPair> levelSpeedPair;

    public float GetValuesBonus()
    {
        return structureValuesPerLevel.StructureIncreasePerLevel[structureLevel];
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
        if (ScalableStructureElement.activeSelf != true)
        {
            ScalableStructureElement.SetActive(true);
        }
        LevelSpeedPair pair = levelSpeedPair.Find(item => item.level == structureLevel);
        if (pair != null)
        {
            float speed = pair.speed;         
            ScalableStructureElement.GetComponent<SpaceRoverMovement>().StartMovement(speed);
        }
        else
        {
            Debug.LogWarning($"Brak skali dla poziomu {structureLevel}.");
        }
    }
}
