using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BonusFactory
{
    public static Bonus CreateBonus(Sprite sprite, IMultiplierStrategy multiplierStrategy, float duration, GameObject prefab)
    {
        return new BonusBuilder().SetSprite(sprite).SetMultiplierStrategy(multiplierStrategy).SetDuration(duration).SetPrefab(prefab).Build();
    }
}
