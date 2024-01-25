using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBuilder 
{
    private Bonus bonus;
    private GameObject bonusObject;

    public BonusBuilder()
    {
        bonus = new Bonus(null, null, 0, 0, 1, null);
    }

    public BonusBuilder SetSprite(Sprite sprite)
    {
        bonus.BonusSprite = sprite;
        return this;
    }

    public BonusBuilder SetMultiplierStrategy(IMultiplierStrategy multiplierStrategy)
    {
        bonus.MultiplierStrategy = multiplierStrategy;
        return this;
    }

    public BonusBuilder SetBonusType(BonusData.BonusType bonusType)
    {
        bonus.BonusType = bonusType;
        return this;
    }

    public BonusBuilder SetFasterProduce(BonusData.FasterProduce fasterProduce)
    {
        bonus.FasterProduce = fasterProduce;
        return this;
    }

    public BonusBuilder SetDuration(float duration)
    {
        bonus.Duration = duration;
        return this;
    }

    public BonusBuilder SetPrefab(GameObject prefab)
    {
        bonus.Prefab = prefab;
        return this;
    }

    public Bonus Build()
    {
        return bonus;
    }
}
