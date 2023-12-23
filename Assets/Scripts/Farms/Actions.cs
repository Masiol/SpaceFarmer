using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public static event Action<string> MoneyFinishedAction;

    public static void InvokeMoneyFinished(string currentFarmName)
    {
        MoneyFinishedAction?.Invoke(currentFarmName);
    }
}
