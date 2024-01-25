using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : Structure
{
    public SolarPanel(StructureData data) : base(data.structureName, data.structureIndex, data.structureLevel, data.structureSprite, data.structurePrice, data.isUnlocked, data.structureType)
    {
        GameObject.Find(data.structureName).GetComponent<SolarPanelController>().Initialize(data);
    }
}
