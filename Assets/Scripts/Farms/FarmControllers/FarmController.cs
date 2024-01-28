using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;

public class FarmController : MonoBehaviour, IFarmUnit
{
    private string farmName;
    private int farmIndex;
    private int farmLevel;
    private Sprite farmImage;
    public int price { get; private set; }
    [HideInInspector] public bool isUnlocked;

    [SerializeField] private GameObject platformFarm;
    [SerializeField] private GameObject VisualPartToUnlock;
    [SerializeField] private GameObject VisualPartAfterUnlock;
    [SerializeField] private GameObject ScalableElementFarm;
    [Space]
    [SerializeField] private FarmValuesPerLevel farmValues;

    private FarmData.FarmState FarmState;
    private FarmProduce farmProduce;
    private FarmData data;
    
    private void OnEnable()
    {
        Actions.MoneyFinishedAction += MoneyFinishedHandler;
    }
    public FarmController(FarmData data)
    {
        this.data = data;
    }
    public void Initialize(string _name, int _index, int _level, Sprite _farmImage, int _price, bool _isUnlocked, FarmData.FarmState _state)
    {
        farmName = _name;
        farmIndex = _index;
        farmLevel = _level;
        farmImage = _farmImage;
        price = _price;
        isUnlocked = _isUnlocked;
        FarmState = _state;
        UpdateFarmState();
        if (isUnlocked)
        {
            // InitializeFarmProduce();
        }
    } public void Interact(string currentFarmName)
    {
        if (FarmState == FarmData.FarmState.Unlocked)
        {
            Debug.Log("interakcja z odblokowana farma");
        }
        else if (FarmState == FarmData.FarmState.Unlockable)
        {
            float i = PlayerMoneyManager.Instance.GetAmount();
            if (i > price)
            {
                FindObjectOfType<AstronautPlayer>().StartSpawnMoney(platformFarm.transform.GetChild(0), currentFarmName);
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
                    VisualPartAfterUnlock.gameObject.SetActive(true);
                    ScalableElementFarm.gameObject.SetActive(true);
                   // VisualPartToUnlock.gameObject.SetActive(false);
                }
                break;
            case FarmData.FarmState.Unlockable:
                {
                    VisualPartToUnlock.gameObject.SetActive(true);
                    ScalableElementFarm.gameObject.SetActive(false);
                    VisualPartAfterUnlock.gameObject.SetActive(false);
                }
                break;
            case FarmData.FarmState.Locked:
                {
                    VisualPartAfterUnlock.gameObject.SetActive(false);
                    VisualPartToUnlock.gameObject.SetActive(false);
                    ScalableElementFarm.gameObject.SetActive(false);
                }
                break;
        }
    }
    public async Task Unlock()
    {
        FarmManager.Instance.farms[farmIndex].isUnlocked = true;
        FarmManager.Instance.farms[farmIndex].farmState = FarmData.FarmState.Unlocked;
        FarmManager.Instance.Initialize();
        PlayerMoneyManager.Instance.SetAmount(-price);     
        InitializeFarmProduce();
        await WaitForAnimationCompletion();
        GetComponentInChildren<VisualPartAfterUnlock>().StartAnimation();
    }  
    public int GetFarmIndex()
    {
        return farmIndex;
    }
    public int GetPrice()
    {
        return price;
    }
    public int GetLevel()
    {
        return farmLevel;
    }

    public string GetFarmName()
    {
        return farmName;
    }

    public Sprite GetFarmIcon()
    { 
        return farmImage;  
    }

    public FarmValuesPerLevel farmValuesPerLevel()
    {
        return farmValues;
    }
    public void Upgrade(int amount)
    {
        FarmData farm = FarmManager.Instance.farms.FirstOrDefault(f => f.farmName == GetFarmName());
        if (farm != null)
        {
            farm.farmLevel += 1;
        }
        PlayerMoneyManager.Instance.SetAmount(-amount);
        this.farmLevel += 1;
        price = farmValues.farmCostPerLevel[farmLevel];
        GetComponentInChildren<FarmInfoUI>().UpgradeInfo();
    }
  

    private void MoneyFinishedHandler(string currentFarmName)
    {
        if (currentFarmName == GetFarmName())
        {
            Unlock();
        }
    } 
    private Task WaitForAnimationCompletion()
    {
        var completionSource = new TaskCompletionSource<object>();
        var visualPart = GetComponentInChildren<VisualPartToUnlock>();
        visualPart.OnAnimationCompleted += () =>
        {
            completionSource.SetResult(null);
        };
        visualPart.StartAnimation();
        return completionSource.Task;
    }
    private void InitializeFarmProduce()
    {
        if (farmProduce == null)
        {
            FarmProduce farm = new FarmProduce();
            farm = farmProduce;
            farmProduce = gameObject.AddComponent<FarmProduce>();
            farmProduce.Initialize(this, farmIndex, farmName, farmValues);
        }
    }  
}
