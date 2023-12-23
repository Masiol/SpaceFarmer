using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public Sprite BonusSprite { get; set; }
    public IMultiplierStrategy MultiplierStrategy { get; set; }
    public float Duration { get; set; }
    public GameObject Prefab;

    public Bonus(Sprite sprite, IMultiplierStrategy multiplierStrategy, float duration, GameObject prefab)
    {
        BonusSprite = sprite;
        MultiplierStrategy = multiplierStrategy;
        Duration = duration;
        Prefab = prefab;
    }
}
