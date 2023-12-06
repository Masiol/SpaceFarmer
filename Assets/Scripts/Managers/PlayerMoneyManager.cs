using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoneyManager : MonoBehaviour
{
    public static PlayerMoneyManager Instance { get; private set; }

    public int startMoneyPlayer;
    [SerializeField] private int playerMoneyAmount { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SetAmount(startMoneyPlayer);
    }

    public void SetAmount(int amount)
    {
        playerMoneyAmount += amount;
    }
    public int GetAmount()
    {
        return playerMoneyAmount;
    }
}
