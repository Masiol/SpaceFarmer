using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]

public class GameData : ScriptableObject
{
    [SerializeField] private int startMoney;
    public int StartMoney => startMoney;
}
