using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRover : Structure
{
    public SpaceRover(StructureData data) : base(data.structureName, data.structureIndex, data.structureLevel, data.structureSprite, data.structurePrice, data.isUnlocked, data.structureType)
    {
        GameObject.Find(data.structureName).GetComponent<SpaceRoverController>().Initialize(data);
    }
}
