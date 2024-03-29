using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FarmData
{
    public string farmName;
    public int farmLevel;
    public int farmIndex;
    public Sprite farmIcon;
    public int price;
    public bool isUnlocked;

    public enum FarmState
    {
        Undefined,
        Unlocked,
        Unlockable,
        Locked
    }
    public FarmState farmState;
}
public class FarmManager : MonoBehaviour
{
    public static FarmManager Instance { get; private set; }
    public List<FarmData> farms = new List<FarmData>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        Initialize();
    }  
    public void Initialize()
    {
        SetStateFarms();
        InitializeFarms(farms);
    } 
    private void InitializeFarms(List<FarmData> farms)
    {
        foreach (FarmData farm in farms)
        {
            IFarm ifarm = CreateFarmFromData(farm);
        }
    }
  
    public void SetStateFarms()
    {
        FarmStateController farmStateController = new FarmStateController();
        farmStateController.SetState();
    } 
    private IFarm CreateFarmFromData(FarmData data)
    {
        IFarm farm = null;
        switch (data.farmIndex)
        {
            case 0:
                farm = new MushroomFarm(data);
                break;
            case 1:
                farm = new ChickenFarm(data);
                break;
            case 2:
                farm = new TomatoFarm(data);
                break;
            case 3:
                farm = new CowFarm(data);
                break;

        }
        return farm;
    }
    
}

