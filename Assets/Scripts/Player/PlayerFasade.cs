using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFasade : MonoBehaviour
{
    public static PlayerFasade instance;

    public MoneySpawner moneySpawner;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public void StartSpawnMoney(Transform EndPoint, string currentFarmName)
    {
        moneySpawner.StartSpawn(EndPoint, currentFarmName);
    }
}
