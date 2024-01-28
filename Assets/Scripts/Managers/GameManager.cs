using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameData gameData;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        PlayerMoneyManager.Instance.SetAmount(gameData.StartMoney);
    }
}
