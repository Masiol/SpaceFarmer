using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ActiveBonus : MonoBehaviour
{   
    private Image bonusBorderImage;
    private Image mainBonusSprite;
    private float initialDuration;
    private float remainingDuration;
    private bool startCounting;
    private string childBorderImageTag = "BonusBorder";
    private string childMainImageTag = "BonusIcon";
    private Bonus activeBonus;  
    
    private void Update()
    {
        if (startCounting)
        {
            remainingDuration -= Time.deltaTime;
            float fillAmount = Mathf.Clamp01(remainingDuration / initialDuration);
            bonusBorderImage.fillAmount = fillAmount;

            if (remainingDuration <= 0)
            {
                startCounting = false;
                gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    } 
    public void Initialize(Bonus bonus)
    { 
        bonusBorderImage = FindChildWithTag(childBorderImageTag);
        mainBonusSprite = FindChildWithTag(childMainImageTag);
        initialDuration = bonus.Duration;
        remainingDuration = initialDuration;
        startCounting = true;
        activeBonus = bonus;

        mainBonusSprite.sprite = bonus.BonusSprite;
        bonusBorderImage.type = Image.Type.Filled;
        bonusBorderImage.fillMethod = Image.FillMethod.Radial360;
        bonusBorderImage.fillAmount = 1f; 
    }  
    public float GetCurrentMultiplier()
    {
        if (activeBonus.BonusType == BonusData.BonusType.MultiplierMoney)
        {
            return activeBonus.MultiplierStrategy.ApplyMultiplier(1);
        }
        return 1;
    }
    public float GetFasterProduce()
    {
        return ((float)activeBonus.FasterProduce);
    }
    private Image FindChildWithTag(string tag)
    {
        foreach(Transform child in transform)
        {
            if(child.CompareTag(tag))
            {
                return child.GetComponent<Image>();
            }
        }
        return null;
    } 
}
