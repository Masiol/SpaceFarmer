using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StructureData
{
    public string structureName;
    public int structureLevel;
    public int structureIndex;
    public Sprite structureSprite;
    public int structurePrice;
    public bool isUnlocked;

    public enum StructureType
    {
        Afk_Income,
        Increase_Production,
        Faster_Production
    }

    public StructureType structureType;
}

public class StructureManager : MonoBehaviour
{
    public static StructureManager Instance;
    public List<StructureData> structures = new List<StructureData>();

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InitializeStructures(structures);
    }
    private void InitializeStructures(List<StructureData> structures)
    {
        foreach (StructureData structure in structures)
        {
            IStructure istructure = CreateStructureFromData(structure);
        }
    }
    private IStructure CreateStructureFromData(StructureData data)
    {
        IStructure structure = null;
        switch (data.structureIndex)
        {
            case 0:
                structure = new SolarPanel(data);
                break;
            case 1:
                structure = new SpaceBase(data);
                break;
            case 2:
                structure = new SpaceRover(data);
                break;
        }
        return structure;
    }
}