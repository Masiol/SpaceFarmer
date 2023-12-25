using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BonusData", menuName = "Bonus")]

public class BonusData : ScriptableObject
{
    public Sprite sprite;

    public enum BonusType
    {
        MultiplierMoney,
        FasterProduce
    }
    public enum Multiplier
    {
        X2,
        X3,
        X5
    }

    public enum FasterProduce
    {
        minus15 = 15,
        minus25 = 25,
        minus30 = 35,
        minus50 = 50

    }

    public FasterProduce SetFasterProduce;
    public Multiplier SetMultiplier;
    public BonusType SetBonusType;

    public float duration;
    public GameObject prefab;
}
