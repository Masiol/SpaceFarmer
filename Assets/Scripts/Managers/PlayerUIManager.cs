using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerMoney;
    public void UpdateAmountVisual(float playerMoneyAmount)
    {
        playerMoney.text = playerMoneyAmount.ToString();
    }
}
