using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class StructureControllerBase<T> : StructureBase where T : StructureData
{
    public string structureName;
    public int structureIndex;
    public int structureLevel;
    public Sprite structureImage;
    public int price;
    public bool isUnlocked;
    public StructureData.StructureType structureType;

    public virtual void Initialize(T data)
    {
        structureName = data.structureName;
        structureIndex = data.structureIndex;
        structureLevel = data.structureLevel;
        structureImage = data.structureSprite;
        price = data.structurePrice;
        isUnlocked = data.isUnlocked;
        structureType = data.structureType;
    }
}