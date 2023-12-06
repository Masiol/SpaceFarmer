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
        // Zaktualizuj up³yniêty czas
        timeElapsed += Time.deltaTime;

        // SprawdŸ, czy up³ynê³o wystarczaj¹co czasu, aby wygenerowaæ pieni¹dze
        if (timeElapsed >= defaultTime)
        {
            // Oblicz, ile pieniêdzy nale¿y wygenerowaæ na podstawie farmLevel i timeElapsed
            float moneyToGenerate = CalculateMoneyToGenerate();

            // Dodaj wygenerowane pieni¹dze do collectedMoney
            collectedMoney += moneyToGenerate;

            // Zresetuj up³yniêty czas, gdy wygenerujesz pieni¹dze
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
