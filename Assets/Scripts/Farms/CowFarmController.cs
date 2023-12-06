using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CowFarmController : MonoBehaviour, IFarmUnit
{
    public string farmName;
    public int farmIndex;
    public int farmLevel;
    public int price;
    public bool isUnlocked;
    public FarmData.FarmState FarmState;
    public GameObject platformFarm;
    public Material[] materials;
    public void Initialize(string _name, int _index, int _level, int _price ,bool _isUnlocked, FarmData.FarmState state)
    {
        farmName = _name;
        farmIndex = _index;
        farmLevel = _level;
        price = _price;
        isUnlocked = _isUnlocked;
        FarmState = state;
        UpdateFarmState();
    }

    public void Interact()
    {
        if (FarmState == FarmData.FarmState.Unlocked)
        {
            Debug.Log("interakcja z odblokowana farma");
        }
        else if (FarmState == FarmData.FarmState.Unlockable)
        {
            int i = PlayerMoneyManager.Instance.GetAmount();
            if (i > price)
            {
                Unlock();
            }
            else
            {
                Debug.Log("brak pieniedzy");
            }
        }
        else
            Debug.Log("farma jesszcze zablokowana");
    }
    public void ExitInteractField()
    {
        Debug.Log("no interact with" + farmName);
    }
    public void UpdateFarmState()
    {
        Renderer renderer = platformFarm.GetComponent<Renderer>();
        switch (FarmState)
        {
            case FarmData.FarmState.Unlocked:
                renderer.material = materials[0];
                break;
            case FarmData.FarmState.Unlockable:
                renderer.material = materials[1];
                break;
            case FarmData.FarmState.Locked:
                renderer.material = materials[2];
                break;
        }
    }
    public void Unlock()
    {
        FarmManager.Instance.farms[farmIndex].isUnlocked = true;
        FarmManager.Instance.farms[farmIndex].farmState = FarmData.FarmState.Unlocked;
        FarmManager.Instance.Initialize();
    }
    public int GetPrice()
    {
        return price;
    }
}
