using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStructure
{
    string StructureName { get; }
    int StructureLevel { get; }
    int StructureIndex { get; }

    Sprite StructureSprite { get; }
    int StructurePrice { get; }
    bool StructureIsUnlocked { get; }
    StructureData.StructureType StructureType { get; }

}
