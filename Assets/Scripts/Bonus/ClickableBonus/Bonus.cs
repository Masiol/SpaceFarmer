using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus
{
    public Sprite BonusSprite { get; set; }
    public IMultiplierStrategy MultiplierStrategy { get; set; }
    public float Duration { get; set; }
    public GameObject Prefab;

    public BonusData.BonusType BonusType;

    public BonusData.FasterProduce FasterProduce;

    public Bonus(Sprite sprite, IMultiplierStrategy multiplierStrategy, BonusData.BonusType bonusType, BonusData.FasterProduce fasterProduce, float duration, GameObject prefab)
    {
        BonusSprite = sprite;
        MultiplierStrategy = multiplierStrategy;
        BonusType = bonusType;
        FasterProduce = fasterProduce;
        Duration = duration;
        Prefab = prefab;
    }
}
