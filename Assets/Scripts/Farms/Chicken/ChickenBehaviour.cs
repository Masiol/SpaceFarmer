using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChickenBehaviour : MonoBehaviour
{ 
    public Transform spawnEggPosition; 
    
    [SerializeField] private GameObject Egg; 

    private float eatCooldown = 5f; 
    private float eatTimer = 0f;
    private bool canSpawn = true;
    private Animator animator;
    AnimationFarmGoodsChicken animationFarmGoodsChicken;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        eatTimer = Random.Range(0f, eatCooldown);
        animationFarmGoodsChicken = GetComponentInParent<AnimationFarmGoodsChicken>();
        float timeToNextLayEgg = animationFarmGoodsChicken.GetFarmInfo().timeBetweenNextSpawnObjects;
        Vector3 maxScale = animationFarmGoodsChicken.GetFarmInfo().maxScale;

        SetChickenRotateToPlayer();
        ScaleChicken(maxScale);
        StartCoroutine(LayEgg(timeToNextLayEgg));
    }   
    private void Update()
    {
        eatTimer -= Time.deltaTime;
        if (eatTimer <= 0f)
        {
            if (Random.value <= 0.3f)
            {
                animator.SetBool("Eat", true);
            }
            else
            {
                animator.SetBool("Eat", false);
            }
            eatTimer = eatCooldown;
        }
    }

    private void ScaleChicken(Vector3 scale)
    {
        this.transform.DOScale(scale, 0.5f).SetEase(Ease.InOutSine);
    }
    private void SetChickenRotateToPlayer()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }
    private IEnumerator LayEgg(float waitTime)
    {
        yield return new WaitForSeconds(waitTime
              * ValueFromActiveBonus.instance.GetActiveBonusProduceFaster()
            / ValueFromActiveBonus.instance.BonusFromStructureForFasterProduce());
        while (canSpawn)
        {
            var go = Instantiate(Egg, spawnEggPosition.position, Quaternion.identity);
            animationFarmGoodsChicken.AddEggToList(go);

            yield return new WaitForSeconds(waitTime
                * ValueFromActiveBonus.instance.GetActiveBonusProduceFaster()
            / ValueFromActiveBonus.instance.BonusFromStructureForFasterProduce());
        }
    }
}
