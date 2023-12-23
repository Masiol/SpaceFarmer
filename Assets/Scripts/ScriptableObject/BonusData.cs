using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BonusData", menuName = "Bonus")]

public class BonusData : ScriptableObject
{
    public Sprite sprite;
    public enum Multiplier
    {
        X2,
        X3,
        X5
    }
    public Multiplier SetMultiplier;

    public float duration;
    public GameObject prefab;
}
