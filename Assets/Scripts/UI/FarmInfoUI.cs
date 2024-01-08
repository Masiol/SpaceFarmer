using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FarmInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI farmName;
    [SerializeField] private TextMeshProUGUI farmLevel;
    [SerializeField] private Image icon;
    private int levelFarm;
    private string nameFarm;
    private string upgradeCost;
    private void Start()
    {
        Invoke("SetFarmInfo", 0.25f); 
    }
    private void SetFarmInfo()
    {
        SetFarmName();
        SetFarmLevel();
    }
    public void UpgradeInfo()
    {
        SetFarmLevel();
    }
    private void SetFarmName()
    {
        nameFarm = GetComponentInParent<FarmController>().GetFarmName();
        farmName.text = nameFarm;
    }
    private void SetFarmLevel()
    {
        levelFarm = GetComponentInParent<FarmController>().GetLevel();
        farmLevel.text = "Level: " + levelFarm.ToString();
    }

}
