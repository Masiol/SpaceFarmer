using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueFromActiveBonus : MonoBehaviour
{
    public static ValueFromActiveBonus instance;

    private void Awake()
    {
        instance = this;
    }
    public float BonusFromStructureForIncreaseProduce()
    {
        SpaceBaseController controller = GameObject.FindObjectOfType<SpaceBaseController>();

        if (controller != null)
        {
            if (controller.GetStructureLevel() > 1)
            {
                return controller.GetValuesBonus();
            }
            else
                return 1;
        }
        else
            return 1f;
    }
    public float BonusFromStructureForFasterProduce()
    {
        SolarPanelController controller = GameObject.FindObjectOfType<SolarPanelController>();

        if (controller != null && controller.structureLevel > 1)
        {
            Debug.Log((float)FasterProduceHelper.GetPercentageBonus(1- controller.GetValuesBonus()));
            return (float)FasterProduceHelper.GetPercentageBonus(1- controller.GetValuesBonus());
        }
        else
            return 1f;
    }

    public float GetActiveBonusProduceIncrease()
    {
        ActiveBonus activeBonus = FindObjectOfType<ActiveBonus>();
        if (activeBonus != null)
        {
            return activeBonus.GetCurrentMultiplier();
        }
        else
            return 1;
    }
    public float GetActiveBonusProduceFaster()
    {
        ActiveBonus activeBonus = FindObjectOfType<ActiveBonus>();
        if (activeBonus != null)
        {
            Debug.Log(1 - (float)FasterProduceHelper.GetPercentage(activeBonus.GetFasterProduce()) + "Active bonus produce faster");
            return 1 - (float)FasterProduceHelper.GetPercentage(activeBonus.GetFasterProduce());
        }
        else
            return 1;
    }
}
