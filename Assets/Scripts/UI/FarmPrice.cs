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
        // Spr�buj uzyska� dost�p do komponentu implementuj�cego IFarmUnit w rodzicu
        IFarmUnit farmScript = GetComponentInParent<IFarmUnit>();

        // Sprawd�, czy skrypt zosta� znaleziony
        if (farmScript != null)
        {
            // Teraz mo�esz uzyska� dost�p do warto�ci price
            int farmPrice = farmScript.GetPrice();
           // Debug.Log("Farm Price: " + farmPrice);

            // Je�li potrzebujesz samego skryptu, mo�esz u�y� GetComponent
            MonoBehaviour scriptComponent = farmScript as MonoBehaviour;
            if (scriptComponent != null)
            {
                // Pobierz informacje o typie skryptu
                Type scriptType = scriptComponent.GetType();

                // Sprawd�, czy metoda GetPrice istnieje w skrypcie
                MethodInfo getPriceMethod = scriptType.GetMethod("GetPrice");

                if (getPriceMethod != null)
                {
                    // Wywo�aj metod� i uzyskaj jej wynik
                    int priceValue = (int)getPriceMethod.Invoke(scriptComponent, null);
                    GetComponent<TextMeshProUGUI>().text = priceValue.ToString();
                    // Teraz masz warto�� z metody GetPrice
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

