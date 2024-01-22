using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class StructureUIElement : MonoBehaviour
{

    public Image iconStructure;

    public TextMeshProUGUI structureName;
    private string structureNameString;

    public TextMeshProUGUI structureLevel;
    private string structureLevelString;

    public TextMeshProUGUI structureBonus;
    public TextMeshProUGUI calculateCurrentBonus;

    public TextMeshProUGUI price;
    private string priceString;
    [SerializeField] private Button upgradeButton;
    private bool farmIsActive;

    private int currentStructureIndex;
    private IStructureController structureController;
    private void OnDisable()
    {
        StopCoroutine(CheckMoneyPeriodically());
    }
    private IEnumerator CheckMoneyPeriodically()
    {
        while (gameObject.activeSelf)
        {
            CheckIfPlayerHasMoney();
            yield return new WaitForSeconds(1f);
        }
    }
    public void SetCurrentFarmIndexAndInitialize(int structureIndex)
    {
        currentStructureIndex = structureIndex;
        IStructureController[] controllers = FindObjectsOfType<MonoBehaviour>()
       .OfType<IStructureController>() 
       .Where(controller => controller.GetStructureIndex() == currentStructureIndex).ToArray();
       if (controllers.Length > 0)
        {
            structureController = controllers[0];
        }  
        SetDataOnUI();
        upgradeButton.onClick.AddListener(UpgradeLogic);
        StartCoroutine(CheckMoneyPeriodically());
    }
    private void UpgradeLogic()
    {
        structureController.Upgrade(structureController.GetStructurePrice());
        UIUpdate();
        CheckIfPlayerHasMoney();
    }
    private void SetDataOnUI()
    {
        if (structureController != null)
        {
            iconStructure.sprite = structureController.GetStructureIcon();
            structureNameString = structureController.GetStructureName();
            structureName.text = structureNameString;
            string type = structureController.GetStructureTypeBonus().ToString();
            structureBonus.text = type.Replace('_', ' ');
            UIUpdate();
        }
    }

    private void UIUpdate()
    {
        structureLevelString = structureController.GetStructureLevel().ToString();
        calculateCurrentBonus.text = StringHelper();
        priceString = structureController.GetStructurePrice().ToString();
        structureLevel.text = structureLevelString;
        price.text = priceString;
    }

    public string StringHelper()
    {
        if (structureController.GetStructureTypeBonus() == StructureData.StructureType.Afk_Income)
        {
            return structureController.GetStructureValuesPerLevel().StructureIncreasePerLevel[structureController.GetStructureLevel() - 1].ToString() + " /min";
        }
        else if (structureController.GetStructureTypeBonus() == StructureData.StructureType.Faster_Production)       
        {
            float bonus = structureController.GetStructureValuesPerLevel().StructureIncreasePerLevel[structureController.GetStructureLevel() - 1];
            float percent = (bonus - 1) * 100;
            int roundedPercentage = Mathf.RoundToInt(percent);
            return roundedPercentage.ToString() + "%"; ;
        }
        else if (structureController.GetStructureTypeBonus() == StructureData.StructureType.Increase_Production)
        {
            return structureController.GetStructureValuesPerLevel().StructureIncreasePerLevel[structureController.GetStructureLevel() - 1].ToString() + "%";
        }
        else
            return "";
    }
    private void CheckIfPlayerHasMoney()
    {
        float i = PlayerMoneyManager.Instance.GetAmount();
        if (i >= structureController.GetStructurePrice())
        {
            upgradeButton.interactable = true;
        }
        else
            upgradeButton.interactable = false;
    }
}

