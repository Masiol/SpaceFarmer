using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFarmGoodsChicken : MonoBehaviour, IParabolicMoveListener, IFarmBehaviour
{ 
    public List<GameObject> Eggs = new List<GameObject>();
    public int maxEggCount;

    [SerializeField] private List<Transform> chickenSpawnPoint = new List<Transform>();
    [SerializeField] private GameObject chickenPrefab;
    [SerializeField] private Transform endPoint;
    [SerializeField] private FarmInfo farmInfo;

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
        for (int i = 0; i < Eggs.Count; i++)
        {
            FloatingToPoint(Eggs[i].transform);
            Eggs.RemoveAt(i);
        }
    }
    public FarmInfo GetFarmInfo()
    {
        return farmInfo;
    }
    public FarmInfo FarmProduceInformations()
    {
        return farmInfo;
    }
}
