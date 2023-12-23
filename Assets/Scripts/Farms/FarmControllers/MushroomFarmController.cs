using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class MushroomFarmController : MonoBehaviour, IFarmUnit
{
    public string farmName;
    public int farmIndex;
    public int farmLevel;
    public Sprite farmImage;
    public int price { get; private set; }
    public bool isUnlocked;
    public FarmData.FarmState FarmState;
    public GameObject platformFarm;
    [Space]
    public GameObject VisualPartToUnlock;
    public GameObject VisualPartAfterUnlock;
    public GameObject ScalableElementFarm;

    [SerializeField] private FarmIncomePerLevel farmIncome;
    private FarmProduce farmProduce;

    public void Initialize(string _name, int _index, int _level,int _price, bool _isUnlocked, FarmData.FarmState state)
    {
        farmName = _name;
        farmIndex = _index;
        farmLevel = _level;
        price = _price;
        isUnlocked = _isUnlocked;
        FarmState = state;
        UpdateFarmState();

        if (isUnlocked)
        {
            InitializeFarmProduce();
        }
    }
    private void OnEnable()
    {
        Actions.MoneyFinishedAction += MoneyFinishedHandler;
    }

    private void MoneyFinishedHandler(string currentFarmName)
    {
        if(currentFarmName == FarmName())
        Unlock();
    }

    public void Interact(string currentFarmName)
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
                PlayerFasade.instance.StartSpawnMoney(platformFarm.transform.GetChild(0), currentFarmName);
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
        switch (FarmState)
        {
            case FarmData.FarmState.Unlocked:
                {
                    //VisualPartAfterUnlock.gameObject.SetActive(true);
                    ScalableElementFarm.gameObject.SetActive(true);
                    VisualPartToUnlock.gameObject.SetActive(false);
                }
                break;
            case FarmData.FarmState.Unlockable:
                {
                    VisualPartToUnlock.gameObject.SetActive(true);
                    ScalableElementFarm.gameObject.SetActive(false);
                    // VisualPartAfterUnlock.gameObject.SetActive(false);
                }
                break;
            case FarmData.FarmState.Locked:
                {
                   // VisualPartAfterUnlock.gameObject.SetActive(false);
                    VisualPartToUnlock.gameObject.SetActive(false);
                    ScalableElementFarm.gameObject.SetActive(false);
                }
                break;
        }
    }
    public void Unlock()
    {
        FarmManager.Instance.farms[farmIndex].isUnlocked = true;
        FarmManager.Instance.farms[farmIndex].farmState = FarmData.FarmState.Unlocked;
        FarmManager.Instance.Initialize();

        PlayerMoneyManager.Instance.SetAmount(-price);
        InitializeFarmProduce();
    }

    private void InitializeFarmProduce()
    {
        if (farmProduce == null)
        {
            FarmProduce farm = new FarmProduce();
            farm = farmProduce;
            farmProduce = gameObject.AddComponent<FarmProduce>();
            farmProduce.Initialize(this, farmIndex, farmName, farmLevel, farmIncome);

        }
    }
    public int GetPrice()
    {
        return price;
    }

    public string FarmName()
    {
        return farmName;
    }
}



