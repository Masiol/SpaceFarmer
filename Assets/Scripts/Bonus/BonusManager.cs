using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public Bonus CreatedBonus { get; private set; }
    public void CreateBonus(BonusData bonusdata)
    {
        BonusBuilder bonusBuilder = new BonusBuilder()
            .SetSprite(bonusdata.sprite)
            .SetMultiplierStrategy(GetStrategy(bonusdata.SetMultiplier.ToString()))
            .SetDuration(bonusdata.duration)
            .SetPrefab(bonusdata.prefab);

        CreatedBonus = bonusBuilder.Build();
        GameObject bonusObject = Instantiate(bonusdata.prefab, Vector3.zero, Quaternion.identity);
        UIBonus ui = new UIBonus();
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
