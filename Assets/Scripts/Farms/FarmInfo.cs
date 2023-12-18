using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FarmInfo", menuName = "Farm")]

public class FarmInfo : ScriptableObject
{
    public GameObject scalableItemPrefab;
    public float timeBetweenNextScale;
    public float timeScaleDuration;
    public Vector3 maxScale;
}
