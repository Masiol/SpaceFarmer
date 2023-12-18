using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMoneyManager : MonoBehaviour
{
    public static PlayerMoneyManager Instance { get; private set; }

    public int startMoneyPlayer;
    private int playerMoneyAmount { get; set; }

    public TextMeshProUGUI playerMoney;

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
        UpdateAmountVisual();
    }
    public int GetAmount()
    {
        return playerMoneyAmount;
    }
    private void UpdateAmountVisual()
    {
        playerMoney.text = playerMoneyAmount.ToString();
    }
}
