using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AnimationFarmGoodsMushroom : MonoBehaviour, IParabolicMoveListener, IFarmBehaviour
{
    private List<Transform> HoldersFarmItem = new List<Transform>();
    public List<Transform> itemsToScale = new List<Transform>();
    private GameObject PrefabItem;
    [SerializeField] private FarmInfo farmInfo;
    [SerializeField] private Transform endPoint;
    [SerializeField] private int maxFarmGoodsCount;
    private int currentGoodsFarmFloatingToDestinationPoint;

    public void StartProcess()
    {
        PrefabItem = farmInfo.scalableItemPrefab;
        InitializeList();
        SpawnElements();
        maxFarmGoodsCount = HoldersFarmItem.Count;
        StartCoroutine(ScaleCoroutine());
    }
    private void InitializeList()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform holder = transform.GetChild(i);
            HoldersFarmItem.Add(holder);
        }
    }
    public void SpawnElements()
    {
        for (int i = 0; i < HoldersFarmItem.Count; i++)
        {
            var go = Instantiate(PrefabItem, HoldersFarmItem[i].transform.position, Quaternion.identity);
            go.transform.localScale = Vector3.zero;
            go.transform.parent = HoldersFarmItem[i];
            go.transform.localPosition = Vector3.zero;
           
            itemsToScale.Add(go.transform);
        }
    }
    private IEnumerator ScaleCoroutine()
    {
        float elapsedTime = 0f;
        float duration = farmInfo.timeScaleDuration;

        while (elapsedTime < duration)
        {
            for (int i = 0; i < itemsToScale.Count; i++)
            {
                itemsToScale[i].localScale = Vector3.Lerp(Vector3.zero, farmInfo.maxScale, elapsedTime / duration);
            }

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        for (int i = 0; i < itemsToScale.Count; i++)
        {
            FloatingToPoint(itemsToScale[i]);
            itemsToScale[i].localScale = Vector3.zero;
        }

        // Scaling complete, send an event or perform any other action
        Debug.Log("Scaling Complete!");

        // Wait for some time before resetting the scale
        yield return new WaitForSeconds(farmInfo.timeBetweenNextScale);

        // Restart the coroutine for continuous scaling
        StartCoroutine(ScaleCoroutine());
    }
  
    public void FloatingToPoint(Transform item)
    {
        var go = Instantiate(item, item.transform.position, Quaternion.identity);
        go.transform.localScale = item.localScale / 2;
        go.gameObject.AddComponent<ParabolicMove>();
        go.GetComponent<ParabolicMove>().MoveOnParabola(item, endPoint, this);
    }

    public void OnParabolicMoveComplete()
    {
        currentGoodsFarmFloatingToDestinationPoint++;
        if (currentGoodsFarmFloatingToDestinationPoint == maxFarmGoodsCount)
        {
            GetComponentInParent<FarmProduce>().Income();
            currentGoodsFarmFloatingToDestinationPoint = 0;
        }

    }
}
