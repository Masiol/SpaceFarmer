using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Reflection;

public class FarmPrice : MonoBehaviour
{
    private void Start()
    {
        Invoke("StartGetPrice", 0.01f);
    }
    private void StartGetPrice()
    {
        IFarmUnit farmScript = GetComponentInParent<IFarmUnit>();
        if (farmScript != null)
        {
            int farmPrice = farmScript.GetPrice();
            MonoBehaviour scriptComponent = farmScript as MonoBehaviour;
            if (scriptComponent != null)
            {
                Type scriptType = scriptComponent.GetType();

                MethodInfo getPriceMethod = scriptType.GetMethod("GetPrice");

                if (getPriceMethod != null)
                {
                    int priceValue = (int)getPriceMethod.Invoke(scriptComponent, null);
                    GetComponent<TextMeshProUGUI>().text = priceValue.ToString();
                }
            }
        }
        else
        {
            Debug.LogError("No script implementing IFarmUnit found in the parent objects hierarchy.");
        }
    }
}

