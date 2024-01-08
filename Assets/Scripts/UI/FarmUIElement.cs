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
    private bool farmIsActive;

    private int currentFarmIndex;
    private FarmController farmController;

    private void OnEnable()
    {
        StartCoroutine(CheckMoneyPeriodically());
    }

    private void OnDisable()
    {
        StopCoroutine(CheckMoneyPeriodically());
    }
    private IEnumerator CheckMoneyPeriodically()
    {
        while (gameObject.activeSelf) // Sprawdza, czy obiekt jest aktywny
        {
            CheckIfPlayerHasMoney();
            yield return new WaitForSeconds(1f); // Czekaj 1 sekundê przed kolejnym sprawdzeniem
        }
    }
    public void SetCurrentFarmIndexAndInitialize(int farmIndex)
    {
        currentFarmIndex = farmIndex;
        SetDataOnUI();
        upgradeButton.onClick.AddListener(UpgradeLogic);
        CheckIfPlayerHasMoney();
    }
    private void SetDataOnUI()
    {
        FarmController[] farmControllers = FindObjectsOfType<FarmController>();

        foreach (FarmController controller in farmControllers)
        {
            if (controller.farmIndex == currentFarmIndex)
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
            //Debug.Log(timeBetweenNextScale);
            float timeScaleDuration = farmController.GetComponentInChildren<IFarmBehaviour>().FarmProduceInformations().timeScaleDuration;
            //Debug.Log(timeScaleDuration);
            float timeBetweenNextSpawnObjects = farmController.GetComponentInChildren<IFarmBehaviour>().FarmProduceInformations().timeBetweenNextSpawnObjects;
            // Debug.Log(timeBetweenNextSpawnObjects);
            SetFarmState(true);
            return farmController.farmValuesPerLevel().farmIncomePerLevel[farmController.GetLevel()] +" /"+ FarmProduceValidate(timeBetweenNextScale, timeScaleDuration, timeBetweenNextSpawnObjects).ToString() +"s";
        }
        else
        {
            SetFarmState(false);
            return "1/1";
        }
    }

    private void SetFarmState(bool state)
    {
        Debug.Log(state);
        farmIsActive = state;
        if (!state)
        {
            transform.GetChild(0).GetComponent<Image>().color = Color.gray;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().color = Color.white;
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
        int i = PlayerMoneyManager.Instance.GetAmount();
        if (i > farmController.GetPrice() && farmIsActive)
        {
            upgradeButton.interactable = true;
        }
        else
            upgradeButton.interactable = false;
    }
}
