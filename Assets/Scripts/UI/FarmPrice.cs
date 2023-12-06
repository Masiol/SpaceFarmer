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
        // Spróbuj uzyskaæ dostêp do komponentu implementuj¹cego IFarmUnit w rodzicu
        IFarmUnit farmScript = GetComponentInParent<IFarmUnit>();

        // SprawdŸ, czy skrypt zosta³ znaleziony
        if (farmScript != null)
        {
            // Teraz mo¿esz uzyskaæ dostêp do wartoœci price
            int farmPrice = farmScript.GetPrice();
           // Debug.Log("Farm Price: " + farmPrice);

            // Jeœli potrzebujesz samego skryptu, mo¿esz u¿yæ GetComponent
            MonoBehaviour scriptComponent = farmScript as MonoBehaviour;
            if (scriptComponent != null)
            {
                // Pobierz informacje o typie skryptu
                Type scriptType = scriptComponent.GetType();

                // SprawdŸ, czy metoda GetPrice istnieje w skrypcie
                MethodInfo getPriceMethod = scriptType.GetMethod("GetPrice");

                if (getPriceMethod != null)
                {
                    // Wywo³aj metodê i uzyskaj jej wynik
                    int priceValue = (int)getPriceMethod.Invoke(scriptComponent, null);
                    GetComponent<TextMeshProUGUI>().text = priceValue.ToString();
                    // Teraz masz wartoœæ z metody GetPrice
                    //Debug.Log("GetPrice Value: " + priceValue);
                }
                else
                {
                   // Debug.LogError("GetPrice method not found in the script.");
                }
            }
        }
        else
        {
            Debug.LogError("No script implementing IFarmUnit found in the parent objects hierarchy.");
        }
    }
}

