using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFarmGoodsChicken : MonoBehaviour, IParabolicMoveListener, IFarmBehaviour
{
    [SerializeField] private List<Transform> chickenSpawnPoint = new List<Transform>();
    [SerializeField] private GameObject chickenPrefab;
    [SerializeField] private Transform endPoint;
    [SerializeField] private FarmInfo farmInfo;
    public List<GameObject> Eggs = new List<GameObject>();

    public int maxEggCount;
    private int currentGoodsFarmFloatingToDestinationPoint;

    public void StartProcess()
    {
        SpawnElements();
    }    
    public void SpawnElements()
    {
        for (int i = 0; i < chickenSpawnPoint.Count; i++)
        {
            var go = Instantiate(chickenPrefab, chickenSpawnPoint[i].transform.position, Quaternion.identity);
            go.transform.parent = transform;
        }
    }
 
    public void FloatingToPoint(Transform T)
    {
        T.gameObject.AddComponent<ParabolicMove>();
        T.GetComponent<ParabolicMove>().MoveOnParabola(T, endPoint, this);
    }

    public void OnParabolicMoveComplete()
    {
        currentGoodsFarmFloatingToDestinationPoint++;
        if (currentGoodsFarmFloatingToDestinationPoint == maxEggCount)
        {
            GetComponentInParent<FarmProduce>().Income();
            currentGoodsFarmFloatingToDestinationPoint = 0;
            
        }
    }

    public void AddEggToList(GameObject egg)
    {
        Eggs.Add(egg);
        CheckEggCount();
    }
    private void CheckEggCount()
    {
        //if(Eggs.Count > maxEggCount - 1)
       // {
            for (int i = 0; i < Eggs.Count; i++)
            {
                FloatingToPoint(Eggs[i].transform);
                Eggs.RemoveAt(i);
            }
        //}
    }

    public FarmInfo GetFarmInfo()
    {
        return farmInfo;
    }

    public float GetActiveBonus()
    {
        ActiveBonus activeBonus = FindObjectOfType<ActiveBonus>();
        if (activeBonus != null)
        {
            return 1 - (float)FasterProduceHelper.GetPercentage(activeBonus.GetFasterProduce());
        }

        return 1;
    }


}
