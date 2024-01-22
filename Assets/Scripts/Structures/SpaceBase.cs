using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBase : Structure
{
    public SpaceBase(StructureData data) : base(data.structureName, data.structureIndex, data.structureLevel, data.structureSprite, data.structurePrice, data.isUnlocked, data.structureType)
    {
        GameObject.Find(data.structureName).GetComponent<SpaceBaseController>().Initialize(data);
    }
}
