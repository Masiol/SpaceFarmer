using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class FarmIncomeUI : MonoBehaviour
{
    public Transform startSpawnPointVisualIncomeEffect;
    public GameObject UI_TextIncome;
    public void Initialize()
    {
        Debug.Log("Initialize");
        UI_TextIncome = Resources.Load<GameObject>("UI/UI_TextIncome");
    }
    public void StartAnimation(int income)
    {
        SpawnTextMeshPro(startSpawnPointVisualIncomeEffect.position, income);
    }
    private void SpawnTextMeshPro(Vector3 position, int income)
    {
        var go = Instantiate(UI_TextIncome, position, Quaternion.identity);
        go.transform.position = position;
        go.GetComponent<TextMeshPro>().text = "+" + income.ToString();


        Sequence sequence = DOTween.Sequence();
        sequence.Append(go.transform.DOMoveY(position.y + 1.5f, 1.25f));
        sequence.Join(go.GetComponent<TextMeshPro>().DOFade(0, 1.25f));
        //sequence.OnComplete(() => Destroy(go.gameObject));
    }
}

