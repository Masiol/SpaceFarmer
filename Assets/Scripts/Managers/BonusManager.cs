using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public Bonus CreatedBonus;
    public void CreateBonus(BonusData bonusdata)
    {
        BonusBuilder bonusBuilder = new BonusBuilder()
            .SetSprite(bonusdata.sprite)
            .SetBonusType(bonusdata.SetBonusType)
            .SetDuration(bonusdata.duration)
            .SetPrefab(bonusdata.prefab);

        if(bonusdata.SetBonusType == BonusData.BonusType.MultiplierMoney)
        {
            bonusBuilder.SetMultiplierStrategy(GetStrategy(bonusdata.SetMultiplier.ToString()));
        }
        else if(bonusdata.SetBonusType == BonusData.BonusType.FasterProduce)
        {
            bonusBuilder.SetFasterProduce(bonusdata.SetFasterProduce);
        }
        CreatedBonus = bonusBuilder.Build();
        GameObject bonusObject = Instantiate(bonusdata.prefab, Vector3.zero, Quaternion.identity);
        bonusObject.AddComponent<GameObjectBonus>();
        bonusObject.GetComponent<GameObjectBonus>().Initialize(bonusdata.duration);
        UIBonus ui = FindObjectOfType<UIBonus>();
        ui.SetBonusOnScreen(CreatedBonus);
    }

    private IMultiplierStrategy GetStrategy(string multiplier)
    {
        switch (multiplier)
        {
            case "X2":
                {
                    return new MultiplierController.x2Multiplier();
                }
            case "X3":
                {
                    return new MultiplierController.x3Multiplier();
                }
            case "X5":
                {
                    return new MultiplierController.x5Multiplier();
                }
            default: return null;
        }
    }
}
