using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMoneyManager : MonoBehaviour
{
    public static PlayerMoneyManager Instance { get; private set; }
    private float playerMoneyAmount { get; set; }

    PlayerUIManager playerUIManager;

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
        playerUIManager = FindObjectOfType<PlayerUIManager>();
    }
    public void SetAmount(float amount)
    {
        playerMoneyAmount += amount;
        playerUIManager.UpdateAmountVisual(playerMoneyAmount);
    }
    public float GetAmount()
    {
        return playerMoneyAmount;
    }
}
