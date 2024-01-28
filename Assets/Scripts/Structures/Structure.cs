using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : IStructure
{
    public string StructureName { get; protected set; }

    public int StructureLevel { get; protected set; }

    public int StructureIndex { get; protected set; }    
    public int StructurePrice { get; protected set; }

    public Sprite StructureSprite { get; protected set; }

    public bool StructureIsUnlocked { get; protected set; }

    public StructureData.StructureType StructureType { get; protected set; }

    public Structure(string name, int index, int farmLevel, Sprite farmIcon, int price, bool isUnlocked, StructureData.StructureType type)
    {
        StructureName = name;
        StructureIndex = index;
        StructureLevel = farmLevel;
        StructureSprite = farmIcon;
        StructurePrice = price;
        StructureIsUnlocked = isUnlocked;
        StructureType = type;
    }
}
