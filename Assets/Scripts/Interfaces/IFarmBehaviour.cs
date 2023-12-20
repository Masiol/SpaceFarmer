using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFarmBehaviour
{
    void StartProcess();
    void SpawnElements();
    void FloatingToPoint(Transform T);
}
