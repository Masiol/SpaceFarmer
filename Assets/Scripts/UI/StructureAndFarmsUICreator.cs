using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureAndFarmsUICreator : MonoBehaviour
{
    [SerializeField] private RectTransform parent;
    public RectTransform UIElement;
    public enum Type
    {
        Farm,
        Structure
    }

    public Type type;
    private void Start()
    {
       if(type == Type.Farm)
        {
            int ID = FindObjectOfType<FarmManager>().farms.Count;
            for (int i = 0; i < ID; i++)
            {
                var go = Instantiate(UIElement, parent.transform);
                go.GetComponent<FarmUIElement>().SetCurrentFarmIndexAndInitialize(i);
                go.SetParent(parent, false);
            }
        }
       else if(type == Type.Structure)
        {
            int ID = FindObjectOfType<StructureManager>().structures.Count;
            for (int i = 0; i < ID; i++)
            {
                var go = Instantiate(UIElement, parent.transform);
                go.GetComponent<StructureUIElement>().SetCurrentFarmIndexAndInitialize(i);
                go.SetParent(parent, false);
            }
        }

    }
}
