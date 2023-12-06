using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public static event Action MoneyFinishedAction;

    public static void InvokeMoneyFinished()
    {
        MoneyFinishedAction?.Invoke();
    }
}
