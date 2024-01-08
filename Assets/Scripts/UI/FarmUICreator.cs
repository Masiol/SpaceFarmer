using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmUICreator : MonoBehaviour
{
    [SerializeField] private RectTransform parent;
    public RectTransform UIFarmElement;
    private void Start()
    {
        int ID = FindObjectOfType<FarmManager>().farms.Count;
        Debug.Log(ID);
        for (int i = 0; i < ID; i++)
        {
            var go = Instantiate(UIFarmElement, parent.transform);
            go.GetComponent<FarmUIElement>().SetCurrentFarmIndexAndInitialize(i);
            go.SetParent(parent, false);
        }   
    }
}
