using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FarmUIElement : MonoBehaviour
{
    public Image iconFarm;

    public TextMeshProUGUI farmName;
    private string farmNameString;

    public TextMeshProUGUI farmLevel;
    private string farmLevelString;

    public TextMeshProUGUI farmProduce;
    private string farmProduceString;

    public TextMeshProUGUI price;
    private string priceString;
    [SerializeField] private Button upgradeButton;

    private int currentFarmIndex;
    private FarmController farmController;

    private void OnDisable()
    {
        StopCoroutine(CheckMoneyPeriodically());
    } 
    public void SetCurrentFarmIndexAndInitialize(int farmIndex)
    {
        currentFarmIndex = farmIndex;
        SetDataOnUI();
        upgradeButton.onClick.AddListener(UpgradeLogic);
        StartCoroutine(CheckMoneyPeriodically());
    }
    private IEnumerator CheckMoneyPeriodically()
    {
        while (gameObject.activeSelf)
        {
            CheckIfPlayerHasMoney();
            yield return new WaitForSeconds(1f);
        }
    }  
    private void SetDataOnUI()
    {
        FarmController[] farmControllers = FindObjectsOfType<FarmController>();

        foreach (FarmController controller in farmControllers)
        {
            if (controller.GetFarmIndex() == currentFarmIndex)
            {
                farmController = controller;
                break;
            }
        }
        if (farmController != null)
        {
            iconFarm.sprite = farmController.GetFarmIcon();
            farmNameString = farmController.GetFarmName();
            farmName.text = farmNameString;
            UIUpdate();
        }
    }
    private string FarmProduceStringBuild()
    {
        IFarmBehaviour farmBehaviour = farmController.GetComponentInChildren<IFarmBehaviour>() as IFarmBehaviour;
        if (farmBehaviour != null && ((MonoBehaviour)farmBehaviour).gameObject.activeSelf)
        {
            float timeBetweenNextScale = farmController.GetComponentInChildren<IFarmBehaviour>().FarmProduceInformations().timeBetweenNextScale;
            float timeScaleDuration = farmController.GetComponentInChildren<IFarmBehaviour>().FarmProduceInformations().timeScaleDuration;
            float timeBetweenNextSpawnObjects = farmController.GetComponentInChildren<IFarmBehaviour>().FarmProduceInformations().timeBetweenNextSpawnObjects;
            return farmController.farmValuesPerLevel().farmIncomePerLevel[farmController.GetLevel()] +" /"+ FarmProduceValidate(timeBetweenNextScale, timeScaleDuration, timeBetweenNextSpawnObjects).ToString() +"s";
        }
        else
        {
            return "1/1";
        }
    }

    private float FarmProduceValidate(float TBNS, float TSD, float TBNSO)
    {
        if(TBNS == 0 && TSD == 0)
        {
            return TBNSO;
        }
        else
        {
            return TBNS + TSD;
        }
    }
    private void UpgradeLogic()
    {
        farmController.Upgrade(farmController.GetPrice());
        UIUpdate();
        CheckIfPlayerHasMoney();
    }
    private void UIUpdate()
    {
        farmLevelString = farmController.GetLevel().ToString();
        priceString = farmController.GetPrice().ToString();
        farmLevel.text = farmLevelString;
        price.text = priceString;
        farmProduce.text = FarmProduceStringBuild();
    }
    private void CheckIfPlayerHasMoney()
    {
        float i = PlayerMoneyManager.Instance.GetAmount();
        if (i >= farmController.GetPrice() && FarmIsActive())
        {
            upgradeButton.interactable = true;
        }
        else
            upgradeButton.interactable = false;
    }
    private bool FarmIsActive()
    {
        if (farmController.isUnlocked)
        {
            return true;
        }
        else
            return false;
    }
}
