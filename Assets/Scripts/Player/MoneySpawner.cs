using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MoneySpawner : MonoBehaviour, IParabolicMoveListener
{
    public GameObject moneyPrefab;      
    private int repeatSpawnMoney = 6;      
    public float waitForNextSpawn = 0.1f;
    public Vector3 spawnRotation = new Vector3(-90f, 90f, 0f);
    private Transform endPoint;
    public void StartSpawn(Transform endpoint)
    {
        endPoint = endpoint;
        StartCoroutine(SpawnMoneyRoutine());
    }
    private IEnumerator SpawnMoneyRoutine()
    {
        for (int i = 0; i < repeatSpawnMoney; i++)
        {
            SendMoneyToPoint(endPoint);

            yield return new WaitForSeconds(waitForNextSpawn);
        }
        Actions.InvokeMoneyFinished();

    }
    private void SendMoneyToPoint(Transform endPoint)
    {
        var go = Instantiate(moneyPrefab, transform.position, Quaternion.Euler(spawnRotation));
        go.AddComponent<ParabolicMove>();
        go.GetComponent<ParabolicMove>().MoveOnParabola(transform, endPoint, this);
    }

    public void OnParabolicMoveComplete()
    {
        return;
    }
}