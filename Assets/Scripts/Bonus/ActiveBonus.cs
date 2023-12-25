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

    public void Initialize(Bonus bonus)
    {
        bonusBorderImage = FindChildWithTag(childBorderImageTag);
        mainBonusSprite = FindChildWithTag(childMainImageTag);
        initialDuration = bonus.Duration;
        remainingDuration = initialDuration;
        startCounting = true;
        activeBonus = bonus;
        // Set the sprite for the bonus
        mainBonusSprite.sprite = bonus.BonusSprite;

        // Set the fill method to radial 360
        bonusBorderImage.type = Image.Type.Filled;
        bonusBorderImage.fillMethod = Image.FillMethod.Radial360;
        bonusBorderImage.fillAmount = 1f; // Start with a full circle
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

    private void Update()
    {
        if (startCounting)
        {
            remainingDuration -= Time.deltaTime;

            // Update the fill amount based on the remaining duration
            float fillAmount = Mathf.Clamp01(remainingDuration / initialDuration);
            bonusBorderImage.fillAmount = fillAmount;

            if (remainingDuration <= 0)
            {
                // Bonus duration has ended, you can add any additional logic here
                startCounting = false;
                // Optionally, trigger some event or deactivate the bonus object
                gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
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
}
