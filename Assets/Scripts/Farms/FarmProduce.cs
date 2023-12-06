using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FarmProduce: MonoBehaviour, IFarmProduce
{
    private IFarmUnit farmUnit;
    [SerializeField] private int farmID;
    [SerializeField] private string farmName;
    [ReadOnly] [SerializeField] private float multiplierFarm;
    [SerializeField] private float collectedMoney;
    [SerializeField] private float timeElapsed;
    private int farmLevel; 
    
    [SerializeField] private float defaultTime;
    [SerializeField] private float moneyProduction;

    DefaultTimersForFarms defaultTimers;

    public void Initialize(IFarmUnit _farm, int _farmID, string _farmName, float _multiplier, int _farmLevel)
    {
        farmUnit = _farm;
        farmID = _farmID;
        farmName = _farmName;
        multiplierFarm = _multiplier;
        farmLevel = _farmLevel;
        timeElapsed = 0f;
        GetDefaultTime();
    }
    private void Start()
    {
        defaultTimers = GameObject.FindObjectOfType<DefaultTimersForFarms>();
    }

    private void Update()
    {
        // Zaktualizuj up�yni�ty czas
        timeElapsed += Time.deltaTime;

        // Sprawd�, czy up�yn�o wystarczaj�co czasu, aby wygenerowa� pieni�dze
        if (timeElapsed >= defaultTime)
        {
            // Oblicz, ile pieni�dzy nale�y wygenerowa� na podstawie farmLevel i timeElapsed
            float moneyToGenerate = CalculateMoneyToGenerate();

            // Dodaj wygenerowane pieni�dze do collectedMoney
            collectedMoney += moneyToGenerate;

            // Zresetuj up�yni�ty czas, gdy wygenerujesz pieni�dze
            timeElapsed = 0f;
        }
    }
    private void GetDefaultTime()
    {
        
    }
    public float CollectedMoney()
    {
        return collectedMoney;
    }
    public float CalculateMoneyToGenerate()
    {

        return 0f;
    }

    public void UpgradeProduce(IFarmUnit farm, int farmLevel)
    {
        throw new System.NotImplementedException();
    }
}
